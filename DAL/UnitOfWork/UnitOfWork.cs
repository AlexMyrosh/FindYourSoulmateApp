using DAL.Context;
using DAL.Models;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MssqlContext _sqlContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private IUserRepository? _userRepository;
        private IInterestRepository? _interestRepository;
        private IAccountRepository? _accountRepository;
        private IChatRepository? _chatRepository;
        private IFeedbackRepository? _feedbackRepository;

        public UnitOfWork(MssqlContext sqlContext, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _sqlContext = sqlContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IUserRepository UserRepository
        {
            get
            {
                _userRepository ??= new UserRepository(_userManager, _sqlContext);
                return _userRepository;
            }
        }

        public IInterestRepository InterestRepository
        {
            get
            {
                _interestRepository ??= new InterestRepository(_sqlContext);
                return _interestRepository;
            }
        }

        public IAccountRepository AccountRepository
        {
            get
            {
                _accountRepository ??= new AccountRepository(_signInManager);
                return _accountRepository;
            }
        }

        public IChatRepository ChatRepository
        {
            get
            {
                _chatRepository ??= new ChatRepository(_sqlContext);
                return _chatRepository;
            }
        }

        public IFeedbackRepository FeedbackRepository
        {
            get
            {
                _feedbackRepository ??= new FeedbackRepository(_sqlContext);
                return _feedbackRepository;
            }
        }

        public void ClearTracking()
        {
            _sqlContext.ChangeTracker.Clear();
        }

        public async Task SaveChangesAsync()
        {
            await _sqlContext.SaveChangesAsync();
        }
    }
}
