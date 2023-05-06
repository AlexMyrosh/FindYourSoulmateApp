using AutoMapper;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.UnitOfWork;

namespace BLL.Services
{
    public class InterestService : IInterestService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public InterestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<InterestModel> AddAsync(InterestModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = _mapper.Map<Interest>(model);
            var addedEntity = await _unitOfWork.InterestRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            var addedModel = _mapper.Map<InterestModel>(addedEntity);
            return addedModel;
        }

        public async Task<InterestModel?> UpdateAsync(InterestModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = _mapper.Map<Interest>(model);
            var updatedEntity = _unitOfWork.InterestRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            var updatedModel = _mapper.Map<InterestModel>(updatedEntity);
            return updatedModel;
        }

        public async Task<InterestModel?> DeletePermanentlyAsync(InterestModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = _mapper.Map<Interest>(model);
            var deletedEntity = _unitOfWork.InterestRepository.DeletePermanently(entity);
            await _unitOfWork.SaveChangesAsync();
            var deletedModel = _mapper.Map<InterestModel>(deletedEntity);
            return deletedModel;
        }

        public async Task<InterestModel?> DeleteTemporarilyAsync(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException($"{nameof(id)} is empty");

            var deletedEntity = await _unitOfWork.InterestRepository.DeleteTemporarilyAsync(id);
            await _unitOfWork.SaveChangesAsync();
            var deletedModel = _mapper.Map<InterestModel>(deletedEntity);
            return deletedModel;
        }

        public async Task<List<InterestModel>> GetAllAsync(bool includeDeleted = false)
        {
            var entities = await _unitOfWork.InterestRepository.GetAllAsync(includeDeleted);
            var models = _mapper.Map<List<InterestModel>>(entities);
            return models;
        }

        public async Task<List<InterestModel>> GetAllWithDetailsAsync(bool includeDeleted = false)
        {
            var entities = await _unitOfWork.InterestRepository.GetAllWithDetailsAsync(includeDeleted);
            var models = _mapper.Map<List<InterestModel>>(entities);
            return models;
        }

        public async Task<InterestModel?> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException($"{nameof(id)} is empty");

            var entity = await _unitOfWork.InterestRepository.GetByIdAsync(id);
            var model = _mapper.Map<InterestModel>(entity);
            return model;
        }

        public async Task<InterestModel?> GetByIdWithDetailsAsync(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException($"{nameof(id)} is empty");

            var entity = await _unitOfWork.InterestRepository.GetByIdWithDetailsAsync(id);
            var model = _mapper.Map<InterestModel>(entity);
            return model;
        }
    }
}
