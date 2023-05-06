using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> AddAsync(User entity);

        public User Update(User entity);

        public User DeletePermanently(User entity);

        public Task<User?> DeleteTemporarilyAsync(Guid id);

        public Task<List<User>> GetAllAsync(bool includeDeleted = false);

        public Task<List<User>> GetAllWithDetailsAsync(bool includeDeleted = false);

        public Task<User?> GetByIdAsync(Guid id);

        public Task<User?> GetByIdWithDetailsAsync(Guid id);
        
        public Task<User?> GetByEmailAsync(string email);

        public Task<User?> GetByEmailWithDetailsAsync(string email);

        public Task<User?> GetByUsernameAsync(string username);

        public Task<User?> GetByUsernameWithDetailsAsync(string username);

        public Task<User?> GetByPhoneNumberAsync(string phoneNumber);

        public Task<User?> GetByPhoneNumberWithDetailsAsync(string phoneNumber);
    }
}