using AutoMapper;
using BLL.Models;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.ViewModels;

namespace PL.Controllers
{
    public class HelpController : Controller
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IMapper _mapper;

        public HelpController(IFeedbackService feedbackService, IMapper mapper){
            _feedbackService = feedbackService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SendFeedback(FeedbackViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var feedBackModel = _mapper.Map<FeedbackModel>(viewModel);
                    await _feedbackService.AddASync(feedBackModel);
                }
                return View("Index");
            }
            catch
            {
                return View("Error");
            }
        } 
    }
}
