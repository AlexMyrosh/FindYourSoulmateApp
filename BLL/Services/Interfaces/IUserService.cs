using BLL.Models;

namespace BLL.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserModel> AddAsync(UserModel model);

        public Task<UserModel?> UpdateAsync(UserModel model);

        public Task<UserModel?> DeletePermanentlyAsync(UserModel model);

        public Task<UserModel?> DeleteTemporarilyAsync(Guid id);

        public Task<List<UserModel>> GetAllAsync(bool includeDeleted = false);

        //public Task<List<UserModel>> GetAllWithDetailsAsync(bool includeDeleted = false);

        public Task<UserModel?> GetByIdAsync(Guid id);

        //public Task<UserModel> GetByIdWithDetailsAsync(Guid id);

        public Task<UserModel?> GetByEmailAsync(string email);

        //public Task<UserModel> GetByEmailWithDetailsAsync(string email);

        public Task<UserModel?> GetByUsernameAsync(string username);

        //public Task<UserModel> GetByUsernameWithDetailsAsync(string username);

        public Task<UserModel?> GetByPhoneNumberAsync(string phoneNumber);

        //public Task<UserModel> GetByPhoneNumberWithDetailsAsync(string phoneNumber);
    }
}