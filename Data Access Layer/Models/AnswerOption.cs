using System;
using System.ComponentModel.DataAnnotations;

namespace Data_Access_Layer.Models
{
    public class AnswerOption
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string OptionText { get; set; }

        [Required]
        public Question Question { get; set; }
    }
}
