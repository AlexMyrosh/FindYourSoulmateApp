using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }

        public IInterestRepository InterestRepository { get; }

        public IAccountRepository AccountRepository { get; }

        public IChatRepository ChatRepository { get; }

        public IFeedbackRepository FeedbackRepository { get; }

        public void ClearTracking();

        public Task SaveChangesAsync();
    }
}
