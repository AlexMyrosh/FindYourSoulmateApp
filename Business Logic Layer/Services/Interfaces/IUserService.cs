using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Business_Logic_Layer.Models;

namespace Business_Logic_Layer.Services.Interfaces
{
    public interface IUserService
    {
        public Task AddAsync(UserModel model);

        public Task UpdateAsync(UserModel model);

        public Task DeletePermanentlyAsync(UserModel model);

        public Task DeleteTemporarilyAsync(Guid id);

        public Task<UserModel> GetByIdAsync(Guid id);

        public Task<UserModel> GetByIdWithDetailsAsync(Guid id);

        public Task<List<UserModel>> GetAllAsync(bool includeDeleted = false);

        public Task<List<UserModel>> GetAllWithDetailsAsync(bool includeDeleted = false);
    }
}