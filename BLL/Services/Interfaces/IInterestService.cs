using BLL.Models;

namespace BLL.Services.Interfaces
{
    public interface IInterestService
    {
        public Task<InterestModel> AddAsync(InterestModel model);

        public Task<InterestModel?> UpdateAsync(InterestModel model);

        public Task<InterestModel?> DeletePermanentlyAsync(InterestModel model);

        public Task<InterestModel?> DeleteTemporarilyAsync(Guid id);

        public Task<List<InterestModel>> GetAllAsync(bool includeDeleted = false);

        public Task<List<InterestModel>> GetAllWithDetailsAsync(bool includeDeleted = false);

        public Task<InterestModel?> GetByIdAsync(Guid id);

        public Task<InterestModel?> GetByIdWithDetailsAsync(Guid id);
    }
}