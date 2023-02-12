using System;
using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels
{
    public class AnswerOptionViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Поле з відповіддю є обов'язковим")]
        [MaxLength(100, ErrorMessage = "Максимальний обсяг назви - 100 символів")]
        public string OptionText { get; set; }

        public QuestionViewModel Question { get; set; }
    }
}
