using Business_Logic_Layer.Models;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services.Interfaces
{
    public interface IEmailService
    {
        public Task SendEmailAsync(UserModel user, string subject, string message);
    }
}