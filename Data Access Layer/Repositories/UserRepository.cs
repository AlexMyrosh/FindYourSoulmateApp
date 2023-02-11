using Data_Access_Layer.Context;
using Data_Access_Layer.Models;
using Data_Access_Layer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Repositories
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

        public void DeletePermanently(User entity)
        {
            _sqlContext.Users.Remove(entity);
        }

        public async Task DeleteTemporarilyAsync(Guid id)
        {
            (await _sqlContext.Users.FindAsync(id)).IsDeleted = true;
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

        public void Update(User entity)
        {
            _sqlContext.Users.Update(entity);
        }

        public void UpdateAnswers(IEnumerable<UserAnswer> answers)
        {
            _sqlContext.UserAnswers.UpdateRange(answers);
        }
    }
}
