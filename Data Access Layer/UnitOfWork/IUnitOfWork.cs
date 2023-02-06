using Data_Access_Layer.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Data_Access_Layer.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IQuestionRepository QuestionRepository { get; }

        public Task SaveChangesAsync();
    }
}
