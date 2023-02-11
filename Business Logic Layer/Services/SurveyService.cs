using AutoMapper;
using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Data_Access_Layer.Models;
using Data_Access_Layer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;

namespace Business_Logic_Layer.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;

        public SurveyService(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task AddAsync(SurveyModel model)
        {
            var entity = _mapper.Map<Survey>(model);
            await _unitOfWork.SurveyRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeletePermanentlyAsync(SurveyModel model)
        {
            var entity = _mapper.Map<Survey>(model);
            _unitOfWork.SurveyRepository.DeletePermanently(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteTemporarilyAsync(Guid id)
        {
            await _unitOfWork.SurveyRepository.DeleteTemporarilyAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<SurveyModel>> GetAllAsync(bool includeDeleted = false)
        {
            var entities = await _unitOfWork.SurveyRepository.GetAllAsync(includeDeleted);
            var models = _mapper.Map<List<SurveyModel>>(entities);
            return models;
        }

        public async Task<List<SurveyModel>> GetAllWithDetailsAsync(bool includeDeleted = false)
        {
            var entities = await _unitOfWork.SurveyRepository.GetAllWithDetailsAsync(includeDeleted);
            var models = _mapper.Map<List<SurveyModel>>(entities);
            return models;
        }

        public async Task<SurveyModel> GetByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.SurveyRepository.GetByIdAsync(id);
            var model = _mapper.Map<SurveyModel>(entity);
            return model;
        }

        public async Task<SurveyModel> GetByIdWithDetailsAsync(Guid id)
        {
            var entity = await _unitOfWork.SurveyRepository.GetByIdWithDetailsAsync(id);
            var model = _mapper.Map<SurveyModel>(entity);
            return model;
        }

        public async Task UpdateAsync(SurveyModel model)
        {
            var entity = _mapper.Map<Survey>(model);
            _unitOfWork.SurveyRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task AnswerProcessing(Guid surveyId)
        {
            var matches = await GetMatches(surveyId);
            var survey = await _unitOfWork.SurveyRepository.GetByIdAsync(surveyId);
            foreach (var match in matches)
            {
                match.ForEach(x=>x.User.Answers = null);
                match.ForEach(x => x.ComparableUser.Answers = null);
                BackgroundJob.Schedule(() => SendEmailsWithResult(match), new TimeSpan(0, 0, 15));
            }
        }

        public async Task SendEmailsWithResult(List<UserScoreModel> match)
        {
            await _emailService.SendEmailAsync(match.First().User, "Результат опитування від Св. Валентина", GetEmailMessage(match));
        }

        private string GetEmailMessage(List<UserScoreModel> model)
        {
            var result = "Ваш список людей які найбліше вам підходять:</br>";
            var peopleList = string.Empty;
            for (int i = 0; i < model.Count; i++)
            {
                peopleList += $"{i + 1}. {model[i].ComparableUser.Name} ({model[i].ComparableUser.TelegramUsername})</br>";
            }

            result += peopleList;
            return result;
        }

        private async Task<List<List<UserScoreModel>>> GetMatches(Guid surveyId)
        {
            var surveyModel = await GetByIdWithDetailsAsync(surveyId);
            var userModels = _mapper.Map<List<UserModel>>(await _unitOfWork.UserRepository.GetAllWithDetailsAsync());

            var usersScore = new double[userModels.Count, userModels.Count, surveyModel.Questions.Count];
            var scoresSummary = new double[userModels.Count, userModels.Count];
            for (var currentUserIndex = 0; currentUserIndex < userModels.Count; currentUserIndex++)
            {
                for (var comparableUserIndex = 0; comparableUserIndex < userModels.Count; comparableUserIndex++)
                {
                    for (var questionIndex = 0; questionIndex < surveyModel.Questions.Count; questionIndex++)
                    {
                        if (currentUserIndex == comparableUserIndex)
                        {
                            usersScore[currentUserIndex, comparableUserIndex, questionIndex] = -1;
                        }
                        else if (userModels[currentUserIndex].Answers[questionIndex].Answer ==
                                 userModels[comparableUserIndex].Answers[questionIndex].Answer)
                        {
                            usersScore[currentUserIndex, comparableUserIndex, questionIndex] =
                                surveyModel.Questions[questionIndex].Coefficient;
                        }

                        scoresSummary[currentUserIndex, comparableUserIndex] +=
                            usersScore[currentUserIndex, comparableUserIndex, questionIndex];
                    }
                }
            }

            var usersCompatibility = new List<List<UserScoreModel>>();

            for (var currentUserIndex = 0; currentUserIndex < userModels.Count; currentUserIndex++)
            {
                var tempDictionary = new List<UserScoreModel>();
                for (var comparableUserIndex = 0; comparableUserIndex < userModels.Count; comparableUserIndex++)
                {
                    tempDictionary.Add(new UserScoreModel
                    {
                        User = userModels[currentUserIndex],
                        Score = scoresSummary[currentUserIndex, comparableUserIndex],
                        ComparableUser = userModels[comparableUserIndex]
                    });
                }

                usersCompatibility.Add(tempDictionary);
            }

            for (var i = 0; i < usersCompatibility.Count; i++)
            {
                usersCompatibility[i] = usersCompatibility[i].OrderByDescending(x => x.Score).ToList();
            }

            return usersCompatibility;
        }
    }
}
