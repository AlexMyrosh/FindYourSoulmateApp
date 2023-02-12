namespace BLL.Models
{
    public class UserScoreModel
    {
        public UserModel User { get; set; }

        public UserModel ComparableUser { get; set; }

        public double Score { get; set; }
    }
}
