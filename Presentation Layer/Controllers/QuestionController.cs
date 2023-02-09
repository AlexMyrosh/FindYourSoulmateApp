using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Presentation_Layer.ViewModels;
using Data_Access_Layer.Models;

namespace Presentation_Layer.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;
        private const int NumberOfInitialOptions = 1;

        public QuestionController(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }


        // GET: QuestionController
        public async Task<ActionResult> Index()
        {
            var models = await _questionService.GetAllWithDetailsAsync();
            var viewModels = _mapper.Map<List<QuestionViewModel>>(models);
            return View(viewModels);
        }

        // GET: QuestionController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _questionService.GetByIdWithDetailsAsync(id);
            var viewModel = _mapper.Map<QuestionViewModel>(model);
            return View(viewModel);
        }

        // GET: QuestionController/Create
        public ActionResult Create()
        {
            var viewModel = new QuestionViewModel(NumberOfInitialOptions);
            return View(viewModel);
        }

        // POST: QuestionController/Create
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

        // GET: QuestionController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var model = await _questionService.GetByIdWithDetailsAsync(id);
            var viewModel = _mapper.Map<QuestionViewModel>(model);
            return View(viewModel);
        }

        // POST: QuestionController/Edit/5
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

        // GET: QuestionController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var model = await _questionService.GetByIdWithDetailsAsync(id);
            var viewModel = _mapper.Map<QuestionViewModel>(model);
            return View(viewModel);
        }

        // POST: QuestionController/Delete/5
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

        [HttpPost]
        public PartialViewResult AddNewOption(QuestionViewModel viewModel, int newValue,Guid questionId)
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
            viewModel.Id = questionId;
            return PartialView("PartialViews/_QuestionOptionsPartial", viewModel);
        }
    }
}
