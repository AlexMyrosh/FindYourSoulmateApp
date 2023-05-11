using System.Security.Claims;
using BLL.Models;

namespace BLL.Services.Interfaces
{
    public interface IContactService
    {
        public Task<List<ContactModel>> GetAllByUser(ClaimsPrincipal principal);
    }
}
