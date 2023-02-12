using DAL.Context;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class UserAnswerRepository : IUserAnswerRepository
    {
        private readonly MssqlContext _sqlContext;

        public UserAnswerRepository(MssqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public void UpdateAnswers(IEnumerable<UserAnswer> entities)
        {
            _sqlContext.UserAnswers.UpdateRange(entities);
        }
    }
}
