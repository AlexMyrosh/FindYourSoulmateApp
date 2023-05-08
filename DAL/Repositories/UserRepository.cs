using System.Security.Claims;
using Bogus;
using DAL.Context;
using DAL.Enums;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly MssqlContext _context;

        public UserRepository(UserManager<User> userManager, MssqlContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task GenerateTestUsers(int count)
        {
            var fakeUserGenerator = new Faker<User>()
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Age, f => f.Random.Int(18, 50))
                .RuleFor(u => u.BirthDate, f => f.Date.Past(18))
                .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
                .RuleFor(u => u.LookingForGender, f => f.PickRandom<LookingForGender>())
                .RuleFor(u => u.RelationType, f => f.PickRandom<RelationType>())
                .RuleFor(u => u.RegistrationDate, DateTime.Now)
                .RuleFor(u => u.Bio, f => f.Lorem.Paragraph())
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
                .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber());

            var password = "tvj9BuZ7+";

            var users = fakeUserGenerator.Generate(count);

            foreach (var user in users)
            {
                user.Interests = await GetRandomInterests(5);
                await AddAsync(user, password);
            }
        }

        private async Task<List<Interest>> GetRandomInterests(int count)
        {
            var allInterests = await _context.Interests.ToListAsync();
            var result = new List<Interest>();
            var rnd = new Random();
            List<int> usedInterestIndexes = new List<int>();
            for (int i = 0; i < count; )
            {
                var interestIndex = rnd.Next(0, allInterests.Count);
                if (usedInterestIndexes.Contains(interestIndex))
                {
                    continue;
                }

                usedInterestIndexes.Add(interestIndex);
                result.Add(allInterests[interestIndex]);
                i++;
            }
            
            return result;
        }

        public async Task<IdentityResult> AddAsync(User entity, string password)
        {
            return await _userManager.CreateAsync(entity, password);
        }

        public User UpdateAsync(User entity)
        {
            return _context.Users.Update(entity).Entity;
        }

        public async Task<IdentityResult> ChangeEmailAsync(User user, string newEmail)
        {
            var token = await _userManager.GenerateChangeEmailTokenAsync(user, newEmail);
            return await _userManager.ChangeEmailAsync(user, newEmail, token);
        }

        public async Task<IdentityResult> ChangeUsernameAsync(User user, string newUsername)
        {
            return await _userManager.SetUserNameAsync(user, newUsername);
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
                .Include(entity => entity.LikedByUsers)
                .Include(entity => entity.LikedUsers)
                .Include(entity => entity.Interests)
                .Where(entity => entity.IsDeleted == false || entity.IsDeleted == includeDeleted)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<User?> GetByIdWithDetailsAsync(string id)
        {
            return await _userManager.Users
                .Include(entity => entity.Interests)
                .Include(entity => entity.LikedUsers)
                .Include(entity => entity.LikedByUsers)
                .Where(entity => entity.Id == id)
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
                .Include(entity => entity.LikedByUsers)
                .Include(entity => entity.LikedUsers)
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
                .Include(entity => entity.LikedByUsers)
                .Include(entity => entity.LikedUsers)
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
                .Include(entity => entity.LikedByUsers)
                .Include(entity => entity.LikedUsers)
                .Where(entity => entity.PhoneNumber == phoneNumber)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetCurrentUserWithDetailsAsync(ClaimsPrincipal principal)
        {
            var id = _userManager.GetUserId(principal);
            var result = await _userManager.Users
                .Include(u => u.Interests)
                .Include(entity => entity.LikedByUsers)
                .Include(entity => entity.LikedUsers)
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public async Task<List<User>> GetOtherUsersWithDetailsAsync(string currentUserId)
        {
            return await _userManager.Users
                .Include(u => u.Interests)
                .Include(entity => entity.LikedByUsers)
                .Include(entity => entity.LikedUsers)
                .Where(user => user.Id != currentUserId)
                .ToListAsync();
        }
    }
}
