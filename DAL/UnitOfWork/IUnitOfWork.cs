using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IQuestionRepository QuestionRepository { get; }

        public ISurveyRepository SurveyRepository { get; }

        public IUserRepository UserRepository { get; }

        public void ClearTracking();

        public Task SaveChangesAsync();
    }
}
