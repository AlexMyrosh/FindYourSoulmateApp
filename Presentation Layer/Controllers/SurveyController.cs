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
        private readonly IMapper _mapper;
        private const int NumberOfInitialQuestions = 1;
        private const int NumberOfInitialOptions = 2;

        public SurveyController(ISurveyService surveyService, IMapper mapper)
        {
            _surveyService = surveyService;
            _mapper = mapper;
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
    }
}
