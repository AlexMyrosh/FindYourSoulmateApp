using DAL.Context;
using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MssqlContext _sqlContext;

        private IUserRepository? _userRepository;
        private IInterestRepository? _interestRepository;

        public UnitOfWork(MssqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public IUserRepository UserRepository
        {
            get
            {
                _userRepository ??= new UserRepository(_sqlContext);
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
