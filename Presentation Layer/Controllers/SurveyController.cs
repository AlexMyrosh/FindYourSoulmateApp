using System;
using AutoMapper;
using Business_Logic_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation_Layer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business_Logic_Layer.Models;
using Presentation_Layer.Constants;

namespace Presentation_Layer.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ISurveyService _surveyService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private const int NumberOfInitialQuestions = 1;
        private const int NumberOfInitialOptions = 2;

        public SurveyController(ISurveyService surveyService, IMapper mapper, IUserService userService)
        {
            _surveyService = surveyService;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<ActionResult> Index()
        {
            var models = await _surveyService.GetAllWithDetailsAsync();
            var viewModels = _mapper.Map<List<SurveyViewModel>>(models);
            return View(viewModels);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _surveyService.GetByIdWithDetailsAsync(id);
            var viewModel = _mapper.Map<SurveyViewModel>(model);
            return View(viewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new SurveyViewModel(NumberOfInitialQuestions);
            viewModel.Questions.ForEach(model=>model.Id = Guid.NewGuid());
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SurveyViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<SurveyModel>(viewModel);
                await _surveyService.AddAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(viewModel);
            }
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var model = await _surveyService.GetByIdWithDetailsAsync(id);
            var viewModel = _mapper.Map<SurveyViewModel>(model);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SurveyViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<SurveyModel>(viewModel);
                await _surveyService.UpdateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(viewModel);
            }
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var model = await _surveyService.GetByIdWithDetailsAsync(id);
            var viewModel = _mapper.Map<SurveyViewModel>(model);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(SurveyViewModel viewModel)
        {
            try
            {
                await _surveyService.DeleteTemporarilyAsync(viewModel.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(viewModel);
            }
        }

        [HttpPost]
        public PartialViewResult AddNewQuestion(SurveyViewModel viewModel, int newValue)
        {
            var question = new List<QuestionViewModel>(newValue);
            for (var i = 0; i < question.Capacity; i++)
            {
                if (viewModel.Questions == null)
                {
                    var model = new QuestionViewModel(NumberOfInitialOptions);
                    question.Add(model);
                }
                else
                {
                    question.Add(viewModel.Questions[i]);
                }
            }

            viewModel.Questions = question;
            return PartialView("PartialViews/_QuestionsPartial", viewModel);
        }

        public async Task<ActionResult> PassSurvey(Guid id)
        {
            var surveyModel = await _surveyService.GetByIdWithDetailsAsync(id);
            var surveyViewModel = _mapper.Map<SurveyViewModel>(surveyModel);
            surveyViewModel.Answers = new List<UserAnswerViewModel>(surveyViewModel.Questions.Count);
            for (var i = 0; i < surveyViewModel.Questions.Count; i++)
            {
                surveyViewModel.Answers.Add(new UserAnswerViewModel());
            }
            return View(surveyViewModel);
        }

        public async Task<ActionResult> SurveyProcessing(SurveyViewModel viewModel)
        {
            var currentUserModel = await _userService.GetOrCreateUserByIdAsync(GetUserId());
            for (var i = 0; i < viewModel.Questions.Count; i++)
            {
                currentUserModel.Answers.Add(new UserAnswerModel
                {
                    Answer = viewModel.Answers[i].Answer,
                    Question = _mapper.Map<QuestionModel>(viewModel.Questions[i])
                });
            }

            await _userService.UpdateAsync(currentUserModel);
            //var result = await _surveyService.AnswerProcessing(viewModel.Id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> SurveyProcess(Guid id)
        {
            await _surveyService.AnswerProcessing(id);
            return RedirectToAction(nameof(Index));
        }

        private Guid GetUserId()
        {
            Guid.TryParse(HttpContext.Items[UserConstants.UserIdCookieKey].ToString(), out var id);
            return id;
        }
    }
}
