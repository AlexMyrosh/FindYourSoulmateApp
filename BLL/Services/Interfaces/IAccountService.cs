using BLL.Models;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services.Interfaces
{
    public interface IAccountService
    {
        public Task SignInAsync(UserModel user, bool isPersistent = false, string? authenticationMethod = null);

        public Task<SignInResult> SignInAsync(string username, string password, bool isPersistent = false);

        public Task SignOutAsync();
    }
}
