using AutoMapper;
using BLL.Models;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.ViewModels;

namespace PL.Controllers
{
    public class ChatController : Controller
    {
        private readonly IUserService _userService;
        private readonly IChatService _chatService;
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ChatController(IUserService userService, 
            IChatService chatService,
            IContactService contactService, 
            IMapper mapper)
        {
            _userService = userService;
            _chatService = chatService;
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string userId)
        {
            try
            {
                var currentUser = await _userService.GetCurrentUserWithDetailsAsync(User);
                var messages = await _chatService.GetMessagesWithDetailsAsync(currentUser.Id, userId);
                return View(new ChatViewModel
                {
                    MessageHistory = _mapper.Map<List<ChatMessageViewModel>>(messages),
                    ChatMessage = new ChatMessageViewModel
                    {
                        ReceiverId = userId
                    },
                    CurrentUserId = currentUser.Id
                });
            }
            catch
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> SendMessage(ChatViewModel viewModel)
        {
            try
            {
                viewModel.ChatMessage.SenderId = (await _userService.GetCurrentUserWithDetailsAsync(User)).Id;
                var model = _mapper.Map<ChatMessageModel>(viewModel.ChatMessage);
                await _chatService.AddMessageAsync(model);
                return RedirectToAction("Index", new { userId = viewModel.ChatMessage.ReceiverId });
            }
            catch
            {
                return View("Error");
            }
        }

        [Authorize]
        public async Task<IActionResult> Contacts()
        {
            try
            {
                var contacts = await _contactService.GetAllByUser(User);
                var viewModels = _mapper.Map<List<ContactViewModel>>(contacts);
                return View(viewModels);
            }
            catch
            {
                return View("Error");
            }
        }
    }
}