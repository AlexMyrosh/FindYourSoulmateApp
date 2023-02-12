using DAL.Context;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MssqlContext _sqlContext;
        private IQuestionRepository _questionRepository;
        private ISurveyRepository _surveyRepository;
        private IUserRepository _userRepository;

        public UnitOfWork(MssqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public IQuestionRepository QuestionRepository
        {
            get
            {
                _questionRepository ??= new QuestionRepository(_sqlContext);
                return _questionRepository;
            }
        }

        public ISurveyRepository SurveyRepository
        {
            get
            {
                _surveyRepository ??= new SurveyRepository(_sqlContext);
                return _surveyRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                _userRepository ??= new UserRepository(_sqlContext);
                return _userRepository;
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
