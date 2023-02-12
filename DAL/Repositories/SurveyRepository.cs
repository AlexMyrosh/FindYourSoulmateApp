using DAL.Context;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly MssqlContext _sqlContext;

        public SurveyRepository(MssqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task AddAsync(Survey entity)
        {
            await _sqlContext.Surveys.AddAsync(entity);
        }

        public void DeletePermanently(Survey entity)
        {
            _sqlContext.Surveys.Remove(entity);
        }

        public async Task DeleteTemporarilyAsync(Guid id)
        {
            var entity = await _sqlContext.Surveys.FindAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
            }
        }

        public async Task<List<Survey>> GetAllAsync(bool includeDeleted = false)
        {
            return await _sqlContext.Surveys
                .Where(entity => entity.IsDeleted == false || entity.IsDeleted == includeDeleted)
                .ToListAsync();
        }

        public async Task<List<Survey>> GetAllWithDetailsAsync(bool includeDeleted = false)
        {
            return await _sqlContext.Surveys
                .Include(entity => entity.Questions)
                .Where(entity => entity.IsDeleted == false || entity.IsDeleted == includeDeleted)
                .ToListAsync();
        }

        public async Task<Survey> GetByIdAsync(Guid id)
        {
            return await _sqlContext.Surveys
                .Where(entity => entity.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Survey> GetByIdWithDetailsAsync(Guid id)
        {
            return await _sqlContext.Surveys
                .Include(entity => entity.Questions)
                .ThenInclude(nestedEntity=>nestedEntity.Options)
                .Where(entity => entity.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Update(Survey entity)
        {
            _sqlContext.Surveys.Update(entity);
        }
    }
}
