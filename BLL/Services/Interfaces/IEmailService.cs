using BLL.Models;

namespace BLL.Services.Interfaces
{
    public interface IEmailService
    {
        public Task SendEmailAsync(UserModel user, string subject, string message);
    }
}