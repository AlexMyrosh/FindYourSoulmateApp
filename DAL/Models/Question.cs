using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Body { get; set; }

        [Required]
        [Range(0.2, 1)]
        public double Coefficient { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public Survey Survey { get; set; }

        public IEnumerable<AnswerOption> Options { get; set; }

        public IEnumerable<UserAnswer> UserAnswers { get; set; }
    }
}
