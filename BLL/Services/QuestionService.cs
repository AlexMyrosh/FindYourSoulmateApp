using AutoMapper;
using BLL.Models;
using DAL.Models;
using DAL.UnitOfWork;
using BLL.Services.Interfaces;

namespace BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IMapper _mapper;
        private readonly  IUnitOfWork _unitOfWork;

        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(QuestionModel model)
        {
            if(model == null) throw new ArgumentNullException(nameof(model));

            var entity = _mapper.Map<Question>(model);
            await _unitOfWork.QuestionRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeletePermanentlyAsync(QuestionModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = _mapper.Map<Question>(model);
            _unitOfWork.QuestionRepository.DeletePermanently(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteTemporarilyAsync(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException($"{nameof(id)} is empty");

            await _unitOfWork.QuestionRepository.DeleteTemporarilyAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<QuestionModel>> GetAllAsync(bool includeDeleted = false)
        {
            var entities = await _unitOfWork.QuestionRepository.GetAllAsync(includeDeleted);
            var models = _mapper.Map<List<QuestionModel>>(entities);
            return models;
        }

        public async Task<List<QuestionModel>> GetAllWithDetailsAsync(bool includeDeleted = false)
        {
            var entities = await _unitOfWork.QuestionRepository.GetAllWithDetailsAsync(includeDeleted);
            var models = _mapper.Map<List<QuestionModel>>(entities);
            return models;
        }

        public async Task<QuestionModel> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException($"{nameof(id)} is empty");

            var entity = await _unitOfWork.QuestionRepository.GetByIdAsync(id);
            var model = _mapper.Map<QuestionModel>(entity);
            return model;
        }

        public async Task<QuestionModel> GetByIdWithDetailsAsync(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException($"{nameof(id)} is empty");

            var entity = await _unitOfWork.QuestionRepository.GetByIdWithDetailsAsync(id);
            var model = _mapper.Map<QuestionModel>(entity);
            return model;
        }

        public async Task UpdateAsync(QuestionModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = _mapper.Map<Question>(model);
            _unitOfWork.QuestionRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
