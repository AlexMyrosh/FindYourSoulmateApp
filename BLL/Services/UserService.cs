using AutoMapper;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IdentityResult> AddAsync(UserModel model, string password)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = _mapper.Map<User>(model);
            var result = await _unitOfWork.UserRepository.AddAsync(entity, password);
            return result;
        }

        public async Task<UserModel> UpdateAsync(UserModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = await _unitOfWork.UserRepository.GetByIdWithDetailsAsync(model.Id);
            var isEmailChanged = entity.Email != model.Email;
            var isUsernameChanged = entity.UserName != model.UserName;
            entity = _mapper.Map(model, entity);

            entity.Interests = new List<Interest>();
            for (int i = 0; i < model.Interests?.Count; i++)
            {
                var interest = await _unitOfWork.InterestRepository.GetByIdAsync(model.Interests[i].Id);
                if (interest != null)
                {
                    entity.Interests.Add(interest);
                }
            }

            var result = _unitOfWork.UserRepository.UpdateAsync(entity);

            if (isEmailChanged)
            {
                await _unitOfWork.UserRepository.ChangeEmailAsync(entity, entity.Email);
            }

            if (isUsernameChanged)
            {
                await _unitOfWork.UserRepository.ChangeUsernameAsync(entity, entity.UserName);
            }

            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<UserModel>(result);
        }

        public async Task UpdateEmail(ClaimsPrincipal principal, string newEmail)
        {
            var entity = await _unitOfWork.UserRepository.GetCurrentUserWithDetailsAsync(principal);
            if (entity == null) return;

            if (entity.Email != newEmail)
            {
                await _unitOfWork.UserRepository.ChangeEmailAsync(entity, newEmail);
                await _unitOfWork.AccountRepository.RefreshSignInAsync(entity);
            }
        }

        public async Task UpdateUsername(ClaimsPrincipal principal, string newUsername)
        {
            var entity = await _unitOfWork.UserRepository.GetCurrentUserWithDetailsAsync(principal);
            if (entity == null) return;

            if (entity.UserName != newUsername)
            {
                await _unitOfWork.UserRepository.ChangeUsernameAsync(entity, newUsername);
                await _unitOfWork.AccountRepository.RefreshSignInAsync(entity);
            }
        }

        public async Task<IdentityResult> DeletePermanentlyAsync(UserModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = _mapper.Map<User>(model);
            var result = await _unitOfWork.UserRepository.DeletePermanentlyAsync(entity);
            return result;
        }

        public async Task<IdentityResult> DeleteTemporarilyAsync(UserModel model)
        {
            if (model == null) throw new ArgumentNullException($"{nameof(model)}");

            var entity = _mapper.Map<User>(model);
            var result = await _unitOfWork.UserRepository.DeleteTemporarilyAsync(entity);
            return result;
        }

        public async Task<List<UserModel>> GetAllAsync(bool includeDeleted = false)
        {
            var entities = await _unitOfWork.UserRepository.GetAllAsync(includeDeleted);
            var models = _mapper.Map<List<UserModel>>(entities);
            return models;
        }

        public async Task<List<UserModel>> GetAllWithDetailsAsync(bool includeDeleted = false)
        {
            var entities = await _unitOfWork.UserRepository.GetAllWithDetailsAsync(includeDeleted);
            var models = _mapper.Map<List<UserModel>>(entities);
            return models;
        }

        public async Task<UserModel?> GetByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException($"{nameof(id)} is null or empty");

            var entity = await _unitOfWork.UserRepository.GetByIdAsync(id);
            var model = _mapper.Map<UserModel>(entity);
            return model;
        }

        public async Task<UserModel?> GetByIdWithDetailsAsync(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException($"{nameof(id)} is null or empty");

            var entity = await _unitOfWork.UserRepository.GetByIdWithDetailsAsync(id.ToString());
            var model = _mapper.Map<UserModel>(entity);
            return model;
        }

        public async Task<UserModel?> GetByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException(nameof(email));

            var entity = await _unitOfWork.UserRepository.GetByEmailAsync(email);
            var model = _mapper.Map<UserModel>(entity);
            return model;
        }

        public async Task<UserModel?> GetByEmailWithDetailsAsync(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException(nameof(email));

            var entity = await _unitOfWork.UserRepository.GetByEmailWithDetailsAsync(email);
            var model = _mapper.Map<UserModel>(entity);
            return model;
        }

        public async Task<UserModel?> GetByUsernameAsync(string username)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentNullException(nameof(username));

            var entity = await _unitOfWork.UserRepository.GetByUsernameAsync(username);
            var model = _mapper.Map<UserModel>(entity);
            return model;
        }

        public async Task<UserModel?> GetByUsernameWithDetailsAsync(string username)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentNullException(nameof(username));

            var entity = await _unitOfWork.UserRepository.GetByUsernameWithDetailsAsync(username);
            var model = _mapper.Map<UserModel>(entity);
            return model;
        }

        public async Task<UserModel?> GetByPhoneNumberAsync(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber)) throw new ArgumentNullException(nameof(phoneNumber));

            var entity = await _unitOfWork.UserRepository.GetByPhoneNumberAsync(phoneNumber);
            var model = _mapper.Map<UserModel>(entity);
            return model;
        }

        public async Task<UserModel?> GetByPhoneNumberWithDetailsAsync(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber)) throw new ArgumentNullException(nameof(phoneNumber));

            var entity = await _unitOfWork.UserRepository.GetByPhoneNumberWithDetailsAsync(phoneNumber);
            var model = _mapper.Map<UserModel>(entity);
            return model;
        }

        public async Task<UserModel?> GetCurrentUserWithDetailsAsync(ClaimsPrincipal principal)
        {
            var entity = await _unitOfWork.UserRepository.GetCurrentUserWithDetailsAsync(principal);
            var model = _mapper.Map<UserModel>(entity);
            return model;
        }

        public async Task<IdentityResult> ChangePasswordAsync(UserModel user, string currentPassword, string newPassword)
        {
            var entity = await _unitOfWork.UserRepository.GetByIdAsync(user.Id);
            return await _unitOfWork.UserRepository.ChangePasswordAsync(entity, currentPassword, newPassword);
        }
    }
}
