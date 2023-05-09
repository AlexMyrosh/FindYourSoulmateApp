using DAL.Context;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly MssqlContext _sqlContext;

        public FeedbackRepository(MssqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task<Feedback> AddAsync(Feedback entity)
        {
            return (await _sqlContext.Feedbacks.AddAsync(entity)).Entity;
        }
    }
}
