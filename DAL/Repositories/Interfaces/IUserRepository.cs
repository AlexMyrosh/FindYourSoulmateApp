using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> AddAsync(User entity);

        public void Update(User entity);

        public Task AddAnswersAsync(IEnumerable<UserAnswer> answers);

        public void DeletePermanently(User entity);

        public Task DeleteTemporarilyAsync(Guid id);

        public Task<User> GetByIdAsync(Guid id);

        public Task<User> GetByEmailAsync(string email);

        public Task<User> GetBySocialMediaUsernameAsync(string socialMediaUsername);

        public Task<User> GetByIdWithDetailsAsync(Guid id);

        public Task<List<User>> GetAllAsync(bool includeDeleted = false);

        public Task<List<User>> GetAllWithDetailsAsync(bool includeDeleted = false);
    }
}