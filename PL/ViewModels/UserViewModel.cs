using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Presentation_Layer.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(int numberOfAnswers)
        {
            Answers = new List<UserAnswerViewModel>(numberOfAnswers);
        }

        public UserViewModel(){}

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Ваше ім'я є обов'язковим")]
        [MaxLength(50, ErrorMessage = "Обсяг імені має бути не більшим ніж 50 символів")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ваш нік в телеграмі є обов'язковим")]
        [MaxLength(50, ErrorMessage = "Нік має бути до 50 символів")]
        public string TelegramUsername { get; set; }

        [Required(ErrorMessage = "Ваш email є обов'язковим")]
        [EmailAddress(ErrorMessage = "Ой-ой, щось це не схоже на електронну скриньку")]
        public string Email { get; set; }

        public Guid LastSurveyPass { get; set; }

        public bool IsDeleted { get; set; }

        public List<UserAnswerViewModel> Answers { get; set; }

    }
}
