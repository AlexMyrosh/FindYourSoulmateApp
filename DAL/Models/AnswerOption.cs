using System.ComponentModel.DataAnnotations;

namespace DAL.Models
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
