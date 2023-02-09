using AutoMapper;
using Business_Logic_Layer.Models;
using Business_Logic_Layer.Services.Interfaces;
using Data_Access_Layer.Models;
using Data_Access_Layer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
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

        public async Task AddAsync(UserModel model)
        {
            var entity = _mapper.Map<User>(model);
            await _unitOfWork.UserRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeletePermanentlyAsync(UserModel model)
        {
            var entity = _mapper.Map<User>(model);
            _unitOfWork.UserRepository.DeletePermanently(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteTemporarilyAsync(Guid id)
        {
            await _unitOfWork.UserRepository.DeleteTemporarilyAsync(id);
            await _unitOfWork.SaveChangesAsync();
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

        public async Task<UserModel> GetByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.UserRepository.GetByIdAsync(id);
            var model = _mapper.Map<UserModel>(entity);
            return model;
        }

        public async Task<UserModel> GetByIdWithDetailsAsync(Guid id)
        {
            var entity = await _unitOfWork.UserRepository.GetByIdWithDetailsAsync(id);
            var model = _mapper.Map<UserModel>(entity);
            return model;
        }

        public async Task UpdateAsync(UserModel model)
        {
            var entity = _mapper.Map<User>(model);
            _unitOfWork.UserRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
