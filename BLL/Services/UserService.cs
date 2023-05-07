using AutoMapper;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;

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
            //await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<IdentityResult> UpdateAsync(UserModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = _mapper.Map<User>(model);
            var result = await _unitOfWork.UserRepository.UpdateAsync(entity);
            //await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<IdentityResult> DeletePermanentlyAsync(UserModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = _mapper.Map<User>(model);
            var result = await _unitOfWork.UserRepository.DeletePermanentlyAsync(entity);
            //await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<IdentityResult> DeleteTemporarilyAsync(UserModel model)
        {
            if (model == null) throw new ArgumentNullException($"{nameof(model)}");

            var entity = _mapper.Map<User>(model);
            var result = await _unitOfWork.UserRepository.DeleteTemporarilyAsync(entity);
            //await _unitOfWork.SaveChangesAsync();
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

        public async Task<UserModel?> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException($"{nameof(id)} is empty");

            var entity = await _unitOfWork.UserRepository.GetByIdAsync(id);
            var model = _mapper.Map<UserModel>(entity);
            return model;
        }

        public async Task<UserModel?> GetByIdWithDetailsAsync(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException($"{nameof(id)} is empty");

            var entity = await _unitOfWork.UserRepository.GetByIdWithDetailsAsync(id);
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
    }
}
