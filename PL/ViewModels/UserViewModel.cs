using Microsoft.AspNetCore.Identity;
using PL.Enums;
using PL.Models;

namespace PL.ViewModels
{
    public class UserViewModel : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        public GenderViewModel Gender { get; set; }

        public string? Bio { get; set; }

        public List<InterestViewModel>? Interests { get; set; }

        public List<Guid>? SelectedInterests { get; set; } = new List<Guid>();

        public LookingForGenderViewModel LookingForGender { get; set; }

        public RelationTypeViewModel RelationType { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime LastLogin { get; set; }

        public bool IsDeleted { get; set; }
    }
}
