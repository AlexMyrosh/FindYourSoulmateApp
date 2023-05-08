namespace BLL.Services.Interfaces
{
    public interface IProfileService
    {
        public Task LikeUser(string currentUserId, string likedUserId);
    }
}
