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
    public class SurveyService : ISurveyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SurveyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(SurveyModel model)
        {
            var entity = _mapper.Map<Survey>(model);
            await _unitOfWork.SurveyRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeletePermanentlyAsync(SurveyModel model)
        {
            var entity = _mapper.Map<Survey>(model);
            _unitOfWork.SurveyRepository.DeletePermanently(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteTemporarilyAsync(Guid id)
        {
            await _unitOfWork.SurveyRepository.DeleteTemporarilyAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<SurveyModel>> GetAllAsync(bool includeDeleted = false)
        {
            var entities = await _unitOfWork.SurveyRepository.GetAllAsync(includeDeleted);
            var models = _mapper.Map<List<SurveyModel>>(entities);
            return models;
        }

        public async Task<List<SurveyModel>> GetAllWithDetailsAsync(bool includeDeleted = false)
        {
            var entities = await _unitOfWork.SurveyRepository.GetAllWithDetailsAsync(includeDeleted);
            var models = _mapper.Map<List<SurveyModel>>(entities);
            return models;
        }

        public async Task<SurveyModel> GetByIdAsync(Guid id)
        {
            var entity = await _unitOfWork.SurveyRepository.GetByIdAsync(id);
            var model = _mapper.Map<SurveyModel>(entity);
            return model;
        }

        public async Task<SurveyModel> GetByIdWithDetailsAsync(Guid id)
        {
            var entity = await _unitOfWork.SurveyRepository.GetByIdWithDetailsAsync(id);
            var model = _mapper.Map<SurveyModel>(entity);
            return model;
        }

        public async Task UpdateAsync(SurveyModel model)
        {
            var entity = _mapper.Map<Survey>(model);
            _unitOfWork.SurveyRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
