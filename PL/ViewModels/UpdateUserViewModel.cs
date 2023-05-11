namespace PL.ViewModels
{
    public class UpdateUserViewModel
    {
        public UserViewModel UserData { get; set; }

        public List<Guid> SelectedInterests { get; set; }
    }
}
