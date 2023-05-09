using BLL.Models;

namespace BLL.Services.Interfaces
{
    public interface IFeedbackService
    {
        public Task<FeedbackModel> AddASync(FeedbackModel model);
    }
}
