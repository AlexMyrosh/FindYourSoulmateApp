using BLL.Enums;
using Microsoft.AspNetCore.Identity;

namespace BLL.Models
{
    public class UserModel : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        public GenderModel Gender { get; set; }

        public string? Bio { get; set; }

        public List<InterestModel>? Interests { get; set; }

        public LookingForGenderModel LookingForGender { get; set; }

        public RelationTypeModel RelationType { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime LastLogin { get; set; }

        public bool IsDeleted { get; set; }

        public List<UserModel> LikedUsers { get; set; }

        public List<UserModel> LikedByUsers { get; set; }

        public List<ChatMessageModel> SentMessages { get; set; }

        public List<ChatMessageModel> ReceivedMessages { get; set; }

        public List<ContactModel> Contacts { get; set; }

        public List<ContactModel> UsersWithThisContact { get; set; }
    }
}
