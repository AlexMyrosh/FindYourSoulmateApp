using Business_Logic_Layer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services.Interfaces
{
    public interface IQuestionService
    {
        public Task AddAsync(QuestionModel model);

        public Task UpdateAsync(QuestionModel model);

        public Task DeletePermanentlyAsync(QuestionModel model);

        public Task DeleteTemporarilyAsync(Guid id);

        public Task<QuestionModel> GetByIdAsync(Guid id);

        public Task<QuestionModel> GetByIdWithDetailsAsync(Guid id);

        public Task<List<QuestionModel>> GetAllAsync(bool includeDeleted = false);

        public Task<List<QuestionModel>> GetAllWithDetailsAsync(bool includeDeleted = false);
    }
}
