using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        public Task AddAsync(Question entity);

        public void Update(Question entity);

        public void DeletePermanently(Question entity);

        public Task DeleteTemporarilyAsync(Guid id);

        public Task<Question> GetByIdAsync(Guid id);

        public Task<Question> GetByIdWithDetailsAsync(Guid id);

        public Task<List<Question>> GetAllAsync(bool includeDeleted = false);

        public Task<List<Question>> GetAllWithDetailsAsync(bool includeDeleted = false);
    }
}
