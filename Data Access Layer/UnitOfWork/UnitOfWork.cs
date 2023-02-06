using Data_Access_Layer.Context;
using Data_Access_Layer.Repositories;
using Data_Access_Layer.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Data_Access_Layer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MssqlContext _sqlContext;
        private IQuestionRepository _questionRepository;

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

        public async Task SaveChangesAsync()
        {
            await _sqlContext.SaveChangesAsync();
        }
    }
}
