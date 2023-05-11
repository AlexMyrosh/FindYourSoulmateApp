using DAL.Enums;
using Microsoft.AspNetCore.Identity;

namespace DAL.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public string? Bio { get; set; }

        public List<Interest>? Interests { get; set; }

        public LookingForGender LookingForGender { get; set; }

        public RelationType RelationType { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime LastLogin { get; set; }

        public bool IsDeleted { get; set; }

        public List<User> LikedUsers { get; set; }

        public List<User> LikedByUsers { get; set; }

        public List<ChatMessage> SentMessages { get; set; }

        public List<ChatMessage> ReceivedMessages { get; set; }

        public List<Contact> Contacts { get; set; }

        public List<Contact> UsersWithThisContact { get; set; }
    }
}