using AutoMapper;
using BLL.Services.Interfaces;
using DAL.UnitOfWork;
using System.Security.Claims;
using BLL.Models;

namespace BLL.Services
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ContactModel>> GetAllByUser(ClaimsPrincipal principal)
        {
            var currentUser = await _unitOfWork.UserRepository.GetCurrentUserWithDetailsAsync(principal);
            var entities = await _unitOfWork.ContactRepository.GetAllContactsForUserAsync(currentUser.Id);
            var models = _mapper.Map<List<ContactModel>>(entities);
            return models;
        }
    }
}
