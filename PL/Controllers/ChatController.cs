using AutoMapper;
using BLL.Models;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.ViewModels;

namespace PL.Controllers
{
    public class ChatController : Controller
    {
        private readonly IUserService _userService;
        private readonly IChatService _chatService;
        private readonly IMapper _mapper;

        public ChatController(IUserService userService, IChatService chatService, IMapper mapper)
        {
            _userService = userService;
            _chatService = chatService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> Index(string userId)
        //{
        //    // Get chat messages between the current user and the selected user
        //    var currentUserId = (await _userService.GetCurrentUserWithDetailsAsync(User)).Id;

        //    var messages = await _chatService.GetMessagesWithDetailsAsync(currentUserId, userId);

        //    var viewModel = new ChatViewModel
        //    {
        //        MessageHistory = _mapper.Map<List<ChatMessageViewModel>>(messages),
        //        ChatMessage = new ChatMessageViewModel()
        //    };

        //    return View(viewModel);
        //}

        //[HttpPost]
        //public async Task<IActionResult> SendMessage(ChatViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //var message = new ChatMessage
        //        //{
        //        //    SenderId = (await _userService.GetCurrentUserWithDetailsAsync(User)).Id,
        //        //    ReceiverId = model.ReceiverId,
        //        //    Content = model.Content,
        //        //    Timestamp = DateTime.UtcNow
        //        //};

        //        var message = _mapper.Map<ChatMessageModel>(model);

        //        await _chatService.AddMessageAsync(message);

        //        return RedirectToAction("Index", new { userId = model.ChatMessage.ReceiverId });
        //    }

        //    var messages = await _chatService.GetMessagesWithDetailsAsync(model.ChatMessage.SenderId, model.ChatMessage.ReceiverId);
        //    model.MessageHistory = _mapper.Map<List<ChatMessageViewModel>>(messages);
        //    return View("Index", model);
        //}
    }
}