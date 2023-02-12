using BLL.Models;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IEmailService
    {
        public Task SendEmailAsync(UserModel user, string subject, string message);
    }
}