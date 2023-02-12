using System;
using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels
{
    public class UserAnswerViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Питання є обов'язковим")]
        public string Answer { get; set; }

        public UserViewModel User { get; set; }

        public QuestionViewModel Question { get; set; }
    }
}
