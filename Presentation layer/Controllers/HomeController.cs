using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Presentation_Layer.ViewModels;

namespace Presentation_Layer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;
        private const int NumberOfInitialOptions = 1;

        public HomeController(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }


        // GET: HomeController
        public async Task<ActionResult> Index()
        {
            var models = await _questionService.GetAllWithDetailsAsync();
            var viewModels = _mapper.Map<List<QuestionViewModel>>(models);
            return View(viewModels);
        }

        // GET: HomeController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _questionService.GetByIdWithDetailsAsync(id);
            var viewModel = _mapper.Map<QuestionViewModel>(model);
            return View(viewModel);
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            var viewModel = new QuestionViewModel(NumberOfInitialOptions);
            return View(viewModel);
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(QuestionViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<QuestionModel>(viewModel);
                await _questionService.AddAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: HomeController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var model = await _questionService.GetByIdWithDetailsAsync(id);
            var viewModel = _mapper.Map<QuestionViewModel>(model);
            return View(viewModel);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(QuestionViewModel viewModel)
        {
            try
            {
                var model = _mapper.Map<QuestionModel>(viewModel);
                await _questionService.UpdateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: HomeController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var model = await _questionService.GetByIdWithDetailsAsync(id);
            var viewModel = _mapper.Map<QuestionViewModel>(model);
            return View(viewModel);
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(QuestionViewModel viewModel)
        {
            try
            {
                await _questionService.DeleteTemporarilyAsync(viewModel.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(viewModel);
            }
        }

        public PartialViewResult AddNewOption(QuestionViewModel viewModel, int newValue)
        {
            var options = new List<AnswerOptionViewModel>(newValue);
            for (var i = 0; i < options.Capacity; i++)
            {
                if (viewModel.Options == null || string.IsNullOrEmpty(viewModel.Options[i].OptionText))
                {
                    options.Add(new AnswerOptionViewModel());
                }
                else
                {
                    options.Add(viewModel.Options[i]);
                }
            }

            viewModel.Options = options;
            return PartialView("PartialViews/_QuestionOptionsPartial", viewModel);
        }
    }
}
