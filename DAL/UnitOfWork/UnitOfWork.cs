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
