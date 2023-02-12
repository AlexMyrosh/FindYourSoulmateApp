using BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace BLL.Services.Interfaces
{
    public interface ISurveyService
    {
        public Task AddAsync(SurveyModel model);

        public Task UpdateAsync(SurveyModel model);

        public Task DeletePermanentlyAsync(SurveyModel model);

        public Task DeleteTemporarilyAsync(Guid id);

        public Task<SurveyModel> GetByIdAsync(Guid id);

        public Task<SurveyModel> GetByIdWithDetailsAsync(Guid id);

        public Task<List<SurveyModel>> GetAllAsync(bool includeDeleted = false);

        public Task<List<SurveyModel>> GetAllWithDetailsAsync(bool includeDeleted = false);

        public Task AnswerProcessing(Guid surveyId);
    }
}