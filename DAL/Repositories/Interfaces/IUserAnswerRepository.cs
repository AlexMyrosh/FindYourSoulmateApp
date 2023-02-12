using DAL.Models;

namespace DAL.Repositories.Interfaces;

public interface IUserAnswerRepository
{
    public void UpdateAnswers(IEnumerable<UserAnswer> answers);
}