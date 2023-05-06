using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface IInterestRepository
    {
        public Task<Interest> AddAsync(Interest entity);

        public Interest Update(Interest entity);

        public Interest DeletePermanently(Interest entity);

        public Task<Interest?> DeleteTemporarilyAsync(Guid id);

        public Task<List<Interest>> GetAllAsync(bool includeDeleted = false);

        public Task<List<Interest>> GetAllWithDetailsAsync(bool includeDeleted = false);

        public Task<Interest?> GetByIdAsync(Guid id);

        public Task<Interest?> GetByIdWithDetailsAsync(Guid id);
    }
}