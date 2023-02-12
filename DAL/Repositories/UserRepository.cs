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

        public async Task AddAnswersAsync(IEnumerable<UserAnswer> answers)
        {
            await _sqlContext.UserAnswers.AddRangeAsync(answers);
        }

        public async Task<User> AddAsync(User entity)
        {
            return (await _sqlContext.Users.AddAsync(entity)).Entity;
        }

        public void DeletePermanently(User entity)
        {
            _sqlContext.Users.Remove(entity);
        }

        public async Task DeleteTemporarilyAsync(Guid id)
        {
            var entity = await _sqlContext.Users.FindAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
            }
        }

        public async Task<List<User>> GetAllAsync(bool includeDeleted = false)
        {
            return await _sqlContext.Users
                .Where(entity => entity.IsDeleted == false || entity.IsDeleted == includeDeleted)
                .ToListAsync();
        }

        public async Task<List<User>> GetAllWithDetailsAsync(bool includeDeleted = false)
        {
            return await _sqlContext.Users
                .Include(entity => entity.Answers)
                .ThenInclude(answer => answer.Question)
                .Where(entity => entity.IsDeleted == false || entity.IsDeleted == includeDeleted)
                .ToListAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _sqlContext.Users.Where(entity => entity.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _sqlContext.Users
                .Where(entity => entity.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetByIdWithDetailsAsync(Guid id)
        {
            return await _sqlContext.Users
                .Include(entity => entity.Answers)
                .ThenInclude(answer => answer.Question)
                .Where(entity => entity.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<User> GetBySocialMediaUsernameAsync(string socialMediaUsername)
        {
            return await _sqlContext.Users.Where(entity => entity.TelegramUsername == socialMediaUsername).FirstOrDefaultAsync();
        }

        public void Update(User entity)
        {
            _sqlContext.Users.Update(entity);
        }
    }
}
