using AutoMapper;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.UnitOfWork;

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

        public async Task<UserModel> AddAsync(UserModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = _mapper.Map<User>(model);
            var addedEntity = await _unitOfWork.UserRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var addedModel = _mapper.Map<UserModel>(addedEntity);
            return addedModel;
        }

        public async Task<UserModel?> UpdateAsync(UserModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = _mapper.Map<User>(model);
            var updatedEntity = _unitOfWork.UserRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            var updatedModel = _mapper.Map<UserModel>(updatedEntity);
            return updatedModel;
        }

        public async Task<UserModel?> DeletePermanentlyAsync(UserModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = _mapper.Map<User>(model);
            var deletedEntity = _unitOfWork.UserRepository.DeletePermanently(entity);
            await _unitOfWork.SaveChangesAsync();
            var deletedModel = _mapper.Map<UserModel>(deletedEntity);
            return deletedModel;
        }

        public async Task<UserModel?> DeleteTemporarilyAsync(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException($"{nameof(id)} is empty");

            var deletedEntity = await _unitOfWork.UserRepository.DeleteTemporarilyAsync(id);
            await _unitOfWork.SaveChangesAsync();
            var deletedModel = _mapper.Map<UserModel>(deletedEntity);
            return deletedModel;
        }

        public async Task<List<UserModel>> GetAllAsync(bool includeDeleted = false)
        {
            var entities = await _unitOfWork.UserRepository.GetAllAsync(includeDeleted);
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

        public async Task<UserModel?> GetByEmailAsync(string email)
        {
            var entity = await _unitOfWork.UserRepository.GetByEmailAsync(email);
            var model = _mapper.Map<UserModel>(entity);
            return model;
        }

        public async Task<UserModel?> GetByUsernameAsync(string username)
        {
            var entity = await _unitOfWork.UserRepository.GetByUsernameAsync(username);
            var model = _mapper.Map<UserModel>(entity);
            return model;
        }

        public async Task<UserModel?> GetByPhoneNumberAsync(string phoneNumber)
        {
            var entity = await _unitOfWork.UserRepository.GetByPhoneNumberAsync(phoneNumber);
            var model = _mapper.Map<UserModel>(entity);
            return model;
        }
    }
}
