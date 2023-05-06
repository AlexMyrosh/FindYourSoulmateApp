using DAL.Context;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MssqlContext _sqlContext;

        public UserRepository(MssqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task<User> AddAsync(User entity)
        {
            return (await _sqlContext.Users.AddAsync(entity)).Entity;
        }

        public User Update(User entity)
        {
            return _sqlContext.Users.Update(entity).Entity;
        }

        public User DeletePermanently(User entity)
        {
            return _sqlContext.Users.Remove(entity).Entity;
        }

        public async Task<User?> DeleteTemporarilyAsync(Guid id)
        {
            var entity = await _sqlContext.Users.FindAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
            }

            return entity;
        }

        public async Task<List<User>> GetAllAsync(bool includeDeleted = false)
        {
            return await _sqlContext.Users
                .Where(entity => entity.IsDeleted == false || entity.IsDeleted == includeDeleted)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _sqlContext.Users.FindAsync(id);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _sqlContext.Users.Where(entity => entity.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _sqlContext.Users.Where(entity => entity.Username == username).FirstOrDefaultAsync();
        }

        public async Task<User?> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _sqlContext.Users.Where(entity => entity.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        }
    }
}
