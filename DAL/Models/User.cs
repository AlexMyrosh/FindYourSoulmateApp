using DAL.Enums;

namespace DAL.Models
{
    public class User
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

        public Gender Gender { get; set; }

        public string? Bio { get; set; }

        public List<Interest> Interests { get; set; }

        public LookingForGender LookingForGender { get; set; }

        public RelationType RelationType { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime LastLogin { get; set; }

        public bool IsDeleted { get; set; }
    }
}