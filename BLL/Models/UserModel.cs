using BLL.Enums;

namespace BLL.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Username { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public GenderModel Gender { get; set; }

        public string? Bio { get; set; }

        public List<InterestModel> Interests { get; set; }

        public LookingForGenderModel LookingForGender { get; set; }

        public RelationTypeModel RelationType { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime LastLogin { get; set; }

        public bool IsDeleted { get; set; }
    }
}
