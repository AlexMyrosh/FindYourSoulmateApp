using System.Security.Claims;

namespace BLL.Services.Interfaces
{
    public interface IProfileService
    {
        public Task LikeUser(ClaimsPrincipal principal, string likedUserId);
    }
}
