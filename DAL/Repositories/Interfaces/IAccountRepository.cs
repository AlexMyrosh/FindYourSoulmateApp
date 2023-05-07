using DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace DAL.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        public Task SignInAsync(User user, bool isPersistent = false, string? authenticationMethod = null);

        public Task<SignInResult> SignInAsync(string username, string password, bool isPersistent = false);

        public Task SignOutAsync();
    }
}