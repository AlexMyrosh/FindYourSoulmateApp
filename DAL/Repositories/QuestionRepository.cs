using DAL.Context;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly MssqlContext _sqlContext;

        public QuestionRepository(MssqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task AddAsync(Question entity)
        {
            await _sqlContext.Questions.AddAsync(entity);
        }

        public void DeletePermanently(Question entity)
        {
            _sqlContext.Questions.Remove(entity);
        }

        public async Task DeleteTemporarilyAsync(Guid id)
        {
            var entity = await _sqlContext.Questions.FindAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
            }
        }

        public async Task<List<Question>> GetAllAsync(bool includeDeleted = false)
        {
            return await _sqlContext.Questions
                .Where(entity => entity.IsDeleted == false || entity.IsDeleted == includeDeleted)
                .ToListAsync();
        }

        public async Task<List<Question>> GetAllWithDetailsAsync(bool includeDeleted = false)
        {
            return await _sqlContext.Questions
                .Include(entity => entity.Options)
                .Include(entity => entity.Survey)
                .Include(entity => entity.UserAnswers)
                .ThenInclude(answer => answer.User)
                .Where(entity => entity.IsDeleted == false || entity.IsDeleted == includeDeleted)
                .ToListAsync();
        }

        public async Task<Question> GetByIdAsync(Guid id)
        {
            return await _sqlContext.Questions
                .Where(entity => entity.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Question> GetByIdWithDetailsAsync(Guid id)
        {
            return await _sqlContext.Questions
                .Include(entity => entity.Options)
                .Include(entity => entity.Survey)
                .Include(entity => entity.UserAnswers)
                .ThenInclude(answer => answer.User)
                .Where(entity => entity.Id == id)
                .FirstOrDefaultAsync();
        }

        public void Update(Question entity)
        {
            _sqlContext.Questions.Update(entity);
        }
    }
}
