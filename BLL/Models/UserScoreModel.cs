namespace Business_Logic_Layer.Models
{
    public class UserScoreModel
    {
        public UserModel User { get; set; }

        public UserModel ComparableUser { get; set; }

        public double Score { get; set; }
    }
}
