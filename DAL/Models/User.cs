using System.ComponentModel.DataAnnotations;
using DAL.Enums;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(50)]
        public string? TelegramUsername { get; set; }

        [EmailAddress]
        public string? Email { get; set;}

        public int? UniversityYear { get; set; }

        public Gender? Gender { get; set; }

        public LookingForGender? LookingForGender { get; set; }

        public RelationType? LookingForRelationType { get; set; }

        public UniversityFaculty? UniversityFaculty { get; set; }

        public string? City { get; set; }

        public bool IsDeleted { get; set; }

        public IEnumerable<UserAnswer> Answers { get; set; }
    }
}
