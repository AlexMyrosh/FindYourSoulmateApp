using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class UserAnswer
    {
        [Required]
        public string Answer { get; set; }

        public User User { get; set; }

        public Guid UserId { get; set; }

        public Question Question { get; set; }

        public Guid QuestionId { get; set; }
    }
}
