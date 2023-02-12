using AutoMapper;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.ViewModels;
using BLL.Models;
using PL.Constants;

namespace PL.Controllers
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

        [HttpPost]
        public async Task<ActionResult> ThankYouPage(SurveyViewModel viewModel)
        {
            if (viewModel.Answers.Count < viewModel.Questions.Count)
            {
                ModelState.AddModelError("LackOfAnswers", "Не всі питання мають відповідь");

                var surveyModel = await _surveyService.GetByIdWithDetailsAsync(viewModel.Id);
                viewModel = _mapper.Map<SurveyViewModel>(surveyModel);
                viewModel.Answers = new List<UserAnswerViewModel>(viewModel.Questions.Count);
                for (var i = 0; i < viewModel.Questions.Count; i++)
                {
                    viewModel.Answers.Add(new UserAnswerViewModel());
                }

                return View("PassSurvey", viewModel);
            }

            var currentUserModel = await _userService.GetByIdAsync(GetUserId());
            for (var i = 0; i < viewModel.Questions.Count; i++)
            {
                currentUserModel.Answers.Add(new UserAnswerModel
                {
                    Answer = viewModel.Answers[i].Answer,
                    Question = _mapper.Map<QuestionModel>(viewModel.Questions[i])
                });
            }

            if((await _userService.GetByIdWithDetailsAsync(GetUserId())).Answers.Count == 0)
            {
                await _userService.AddAnswers(currentUserModel);
            }
            else
            {
                await _userService.UpdateAnswers(currentUserModel);
            }

            return View();
        }

        private Guid GetUserId()
        {
            Guid.TryParse(HttpContext.Items[UserConstants.UserIdCookieKey].ToString(), out var id);
            return id;
        }
    }
}
