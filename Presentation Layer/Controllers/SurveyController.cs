using System;
using AutoMapper;
using Business_Logic_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation_Layer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business_Logic_Layer.Models;

namespace Presentation_Layer.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ISurveyService _surveyService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private const int NumberOfInitialQuestions = 1;
        private const int NumberOfInitialOptions = 2;
        private const string CookieKey = "UserId";

        public SurveyController(ISurveyService surveyService, IMapper mapper, IUserService userService)
        {
            _surveyService = surveyService;
            _mapper = mapper;
            _userService = userService;
        }

        // GET: SurveyController
        public async Task<ActionResult> Index()
        {
            var models = await _surveyService.GetAllWithDetailsAsync();
            var viewModels = _mapper.Map<List<SurveyViewModel>>(models);
            return View(viewModels);
        }

        // GET: SurveyController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _surveyService.GetByIdWithDetailsAsync(id);
            var viewModel = _mapper.Map<SurveyViewModel>(model);
            return View(viewModel);
        }

        // GET: SurveyController/Create
        public ActionResult Create()
        {
            var viewModel = new SurveyViewModel(NumberOfInitialQuestions);
            viewModel.Questions.ForEach(model=>model.Id = Guid.NewGuid());
            return View(viewModel);
        }

        // POST: SurveyController/Create
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

        // GET: SurveyController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var model = await _surveyService.GetByIdWithDetailsAsync(id);
            var viewModel = _mapper.Map<SurveyViewModel>(model);
            return View(viewModel);
        }

        // POST: SurveyController/Edit/5
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

        // GET: SurveyController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var model = await _surveyService.GetByIdWithDetailsAsync(id);
            var viewModel = _mapper.Map<SurveyViewModel>(model);
            return View(viewModel);
        }

        // POST: SurveyController/Delete/5
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

        // POST: SurveyController/PassSurvey/5
        public async Task<ActionResult> PassSurvey(Guid id)
        {
            var userId = GetUserId();
            var currentUser = await _userService.GetByIdAsync(userId);
            if (currentUser == null)
            {
                var userViewModel = new UserViewModel(100)
                {
                    Id = userId
                };
                currentUser = _mapper.Map<UserModel>(userViewModel);
                await _userService.AddAsync(currentUser);
            }
            else
            {
                currentUser.Answers = new List<UserAnswerModel>(100);
            }

            var model = await _surveyService.GetByIdWithDetailsAsync(id);

            for (var i = 0; i < currentUser.Answers.Capacity; i++)
            {
                currentUser.Answers.Add(new UserAnswerModel
                {
                    User = currentUser,
                    Id = Guid.NewGuid(),
                    Question = model.Questions[i]
                });
            }
            var viewModel = _mapper.Map<SurveyViewModel>(model);
            viewModel.User = _mapper.Map<UserViewModel>(currentUser);

            return View(viewModel);
        }

        public async Task<ActionResult> SurveyProcessing(SurveyViewModel viewModel)
        {
            return RedirectToAction(nameof(Index));
        }

        private Guid GetUserId()
        {
            Guid.TryParse(HttpContext.Items[CookieKey].ToString(), out var id);
            return id;
        }

    }
}
