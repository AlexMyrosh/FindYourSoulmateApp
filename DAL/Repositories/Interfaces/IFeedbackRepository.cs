using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface IFeedbackRepository
    {
        public Task<Feedback> AddAsync(Feedback entity);
    }
}
