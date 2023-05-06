using PL.Enums;
using PL.Models;

namespace PL.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int Age { get; set; }

        public string? Username { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public GenderViewModel Gender { get; set; }

        public string? Bio { get; set; }

        public List<InterestViewModel>? Interests { get; set; }

        public LookingForGenderViewModel LookingForGender { get; set; }

        public RelationTypeViewModel RelationType { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime LastLogin { get; set; }

        public bool IsDeleted { get; set; }
    }
}
