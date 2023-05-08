using AutoMapper;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task SignInAsync(UserModel user, bool isPersistent = false, string? authenticationMethod = null)
        {
            var entity = _mapper.Map<User>(user);
            await _unitOfWork.AccountRepository.SignInAsync(entity, isPersistent, authenticationMethod);
        }

        public async Task<SignInResult> SignInAsync(string username, string password, bool isPersistent = false)
        {
            return await _unitOfWork.AccountRepository.SignInAsync(username, password, isPersistent);
        }

        public async Task SignOutAsync()
        {
            await _unitOfWork.AccountRepository.SignOutAsync();
        }

        public async Task RefreshSignInAsync(UserModel user)
        {
            var entity = _mapper.Map<User>(user);
            await _unitOfWork.AccountRepository.RefreshSignInAsync(entity);
        }
    }
}
