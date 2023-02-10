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

        public SurveyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
            BackgroundJob.Schedule(() => SendEmailsWithResult(matches), survey.StopDateTime - DateTime.Now);
        }

        public async Task SendEmailsWithResult(List<Dictionary<Guid, double>> matches)
        {

        }

        private async Task<List<Dictionary<Guid, double>>> GetMatches(Guid surveyId)
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
                        else if (userModels[currentUserIndex].Answers[questionIndex].Id ==
                                 userModels[comparableUserIndex].Answers[questionIndex].Id)
                        {
                            usersScore[currentUserIndex, comparableUserIndex, questionIndex] =
                                surveyModel.Questions[questionIndex].Coefficient;
                        }

                        scoresSummary[currentUserIndex, comparableUserIndex] +=
                            usersScore[currentUserIndex, comparableUserIndex, questionIndex];
                    }
                }
            }

            var usersCompatibility = new List<Dictionary<Guid, double>>();

            for (var currentUserIndex = 0; currentUserIndex < userModels.Count; currentUserIndex++)
            {
                var tempDictionary = new Dictionary<Guid, double>();
                for (var comparableUserIndex = 0; comparableUserIndex < userModels.Count; comparableUserIndex++)
                {
                    tempDictionary.Add(userModels[comparableUserIndex].Id,
                        scoresSummary[currentUserIndex, comparableUserIndex]);
                }

                usersCompatibility.Add(tempDictionary);
            }

            for (var i = 0; i < usersCompatibility.Count; i++)
            {
                usersCompatibility[i] = usersCompatibility[i].OrderByDescending(x => x.Value)
                    .ToDictionary(y => y.Key, y => y.Value);
            }

            return usersCompatibility;
        }
    }
}
