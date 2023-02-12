using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string TelegramUsername { get; set; }

        [EmailAddress]
        public string Email { get; set;}

        public bool IsDeleted { get; set; }

        public IEnumerable<UserAnswer> Answers { get; set; }
    }
}
