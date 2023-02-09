using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories.Interfaces
{
    public interface ISurveyRepository
    {
        public Task AddAsync(Survey entity);

        public void Update(Survey entity);

        public void DeletePermanently(Survey entity);

        public Task DeleteTemporarilyAsync(Guid id);

        public Task<Survey> GetByIdAsync(Guid id);

        public Task<Survey> GetByIdWithDetailsAsync(Guid id);

        public Task<List<Survey>> GetAllAsync(bool includeDeleted = false);

        public Task<List<Survey>> GetAllWithDetailsAsync(bool includeDeleted = false);
    }
}
