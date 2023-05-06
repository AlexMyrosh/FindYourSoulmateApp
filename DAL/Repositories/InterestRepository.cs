using DAL.Context;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class InterestRepository : IInterestRepository
    {
        private readonly MssqlContext _sqlContext;

        public InterestRepository(MssqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task<Interest> AddAsync(Interest entity)
        {
            return (await _sqlContext.Interests.AddAsync(entity)).Entity;
        }

        public Interest Update(Interest entity)
        {
            return _sqlContext.Interests.Update(entity).Entity;
        }

        public Interest DeletePermanently(Interest entity)
        {
            return _sqlContext.Interests.Remove(entity).Entity;
        }

        public async Task<Interest?> DeleteTemporarilyAsync(Guid id)
        {
            var entity = await _sqlContext.Interests.FindAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
            }

            return entity;
        }

        public async Task<List<Interest>> GetAllAsync(bool includeDeleted = false)
        {
            return await _sqlContext.Interests
                .Where(entity => entity.IsDeleted == false || entity.IsDeleted == includeDeleted)
                .ToListAsync();
        }

        public async Task<List<Interest>> GetAllWithDetailsAsync(bool includeDeleted = false)
        {
            return await _sqlContext.Interests
                .Include(entity=> entity.Users)
                .Where(entity => entity.IsDeleted == false || entity.IsDeleted == includeDeleted)
                .ToListAsync();
        }

        public async Task<Interest?> GetByIdAsync(Guid id)
        {
            return await _sqlContext.Interests.FindAsync(id);
        }

        public async Task<Interest?> GetByIdWithDetailsAsync(Guid id)
        {
            return await _sqlContext.Interests
                .Include(entity => entity.Users)
                .Where(entity => entity.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
