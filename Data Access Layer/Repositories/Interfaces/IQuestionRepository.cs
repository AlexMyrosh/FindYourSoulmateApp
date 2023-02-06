using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        public Task AddAsync(Question entity);

        public void Update(Question entity);

        public void DeletePermanently(Question entity);

        public Task DeleteTemporarilyAsync(Guid id);

        public Task<Question> GetByIdAsync(Guid id);

        public Task<Question> GetByIdWithDetailsAsync(Guid id);

        public Task<List<Question>> GetAllAsync(bool includeDeleted = false);

        public Task<List<Question>> GetAllWithDetailsAsync(bool includeDeleted = false);
    }
}
