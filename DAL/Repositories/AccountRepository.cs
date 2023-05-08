using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DAL.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SignInManager<User> _signInManager;

        public AccountRepository(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task SignInAsync(User user, bool isPersistent = false, string? authenticationMethod = null)
        {
            await _signInManager.SignInAsync(user, isPersistent, authenticationMethod);
        }

        public async Task<SignInResult> SignInAsync(string username, string password, bool isPersistent = false)
        {
            return await _signInManager.PasswordSignInAsync(username, password, isPersistent, false);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task RefreshSignInAsync(User user)
        {
            await _signInManager.RefreshSignInAsync(user);
        }
    }
}