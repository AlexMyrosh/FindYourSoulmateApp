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
            (await _sqlContext.Surveys.FindAsync(id)).IsDeleted = true;
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
                .Where(entity => entity.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Update(Survey entity)
        {
            _sqlContext.Surveys.Update(entity);
        }
    }
}
