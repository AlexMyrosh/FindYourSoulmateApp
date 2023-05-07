using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> AddAsync(User entity, string password)
        {
            return await _userManager.CreateAsync(entity, password);
        }

        public async Task<IdentityResult> UpdateAsync(User entity)
        {
            return await _userManager.UpdateAsync(entity);
        }

        public async Task<IdentityResult> DeletePermanentlyAsync(User entity)
        {
            return await _userManager.DeleteAsync(entity);
        }

        public async Task<IdentityResult> DeleteTemporarilyAsync(User entity)
        {
            entity.IsDeleted = true;
            return await _userManager.UpdateAsync(entity);
        }

        public async Task<List<User>> GetAllAsync(bool includeDeleted = false)
        {
            return await _userManager.Users
                .Where(entity => entity.IsDeleted == false || entity.IsDeleted == includeDeleted)
                .ToListAsync();
        }

        public async Task<List<User>> GetAllWithDetailsAsync(bool includeDeleted = false)
        {
            return await _userManager.Users
                .Include(entity=> entity.Interests)
                .Where(entity => entity.IsDeleted == false || entity.IsDeleted == includeDeleted)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<User?> GetByIdWithDetailsAsync(Guid id)
        {
            return await _userManager.Users
                .Include(entity => entity.Interests)
                .Where(entity => entity.Id == id.ToString())
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _userManager.Users
                .Where(entity => entity.Email == email)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetByEmailWithDetailsAsync(string email)
        {
            return await _userManager.Users
                .Include(entity => entity.Interests)
                .Where(entity => entity.Email == email)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _userManager.Users
                .Where(entity => entity.UserName == username)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetByUsernameWithDetailsAsync(string username)
        {
            return await _userManager.Users
                .Include(entity => entity.Interests)
                .Where(entity => entity.UserName == username)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _userManager.Users
                .Where(entity => entity.PhoneNumber == phoneNumber)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetByPhoneNumberWithDetailsAsync(string phoneNumber)
        {
            return await _userManager.Users
                .Include(entity => entity.Interests)
                .Where(entity => entity.PhoneNumber == phoneNumber)
                .FirstOrDefaultAsync();
        }
    }
}
