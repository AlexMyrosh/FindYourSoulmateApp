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

        public async Task AddAsync(UserModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = _mapper.Map<User>(model);
            await _unitOfWork.UserRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeletePermanentlyAsync(UserModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = _mapper.Map<User>(model);
            _unitOfWork.UserRepository.DeletePermanently(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteTemporarilyAsync(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException($"{nameof(id)} is empty");

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
            if (id == Guid.Empty) throw new ArgumentException($"{nameof(id)} is empty");

            var entity = await _unitOfWork.UserRepository.GetByIdAsync(id);
            var model = _mapper.Map<UserModel>(entity);
            return model;
        }

        public async Task<UserModel> GetByIdWithDetailsAsync(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException($"{nameof(id)} is empty");

            var entity = await _unitOfWork.UserRepository.GetByIdWithDetailsAsync(id);
            var model = _mapper.Map<UserModel>(entity);
            return model;
        }

        public async Task<UserModel> GetOrCreateUserByIdAsync(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentException($"{nameof(id)} is empty");

            var entity = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (entity == null)
            {
                entity = await _unitOfWork.UserRepository.AddAsync(new User
                {
                    Id = id
                });
                await _unitOfWork.SaveChangesAsync();
            }

            var model = _mapper.Map<UserModel>(entity);
            return model;
        }

        public async Task UpdateAsync(UserModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = _mapper.Map<User>(model);
            foreach (var entityAnswer in entity.Answers)
            {
                entityAnswer.Question = await _unitOfWork.QuestionRepository.GetByIdAsync(entityAnswer.Question.Id);
            }
            _unitOfWork.ClearTracking();
            _unitOfWork.UserRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task AddAnswers(UserModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = _mapper.Map<User>(model);
            _unitOfWork.ClearTracking();
            foreach (var entityAnswer in entity.Answers)
            {
                entityAnswer.UserId = entity.Id;
                entityAnswer.Question = null;
            }
            await _unitOfWork.UserRepository.AddAnswersAsync(entity.Answers);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAnswers(UserModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var entity = _mapper.Map<User>(model);
            _unitOfWork.ClearTracking();
            foreach (var entityAnswer in entity.Answers)
            {
                entityAnswer.UserId = entity.Id;
                entityAnswer.Question = null;
            }
            _unitOfWork.UserAnswerRepository.UpdateAnswers(entity.Answers);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<UserModel> GetByEmailAsync(string email)
        {
            var entity = await _unitOfWork.UserRepository.GetByEmailAsync(email);
            var model = _mapper.Map<UserModel>(entity);
            return model;
        }

        public async Task<UserModel> GetBySocialMediaUsernameAsync(string socialMediaUsername)
        {
            var entity = await _unitOfWork.UserRepository.GetBySocialMediaUsernameAsync(socialMediaUsername);
            var model = _mapper.Map<UserModel>(entity);
            return model;
        }
    }
}
