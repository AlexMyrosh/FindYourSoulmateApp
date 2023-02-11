using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace Presentation_Layer.ViewModels
{
    public class SurveyViewModel
    {
        public SurveyViewModel() { }

        public SurveyViewModel(int numberOfOptions)
        {
            const int numberOfInitialOptions = 2;
            Questions = new List<QuestionViewModel>(numberOfOptions);
            for (var i = 0; i < Questions.Capacity; i++)
            {
                Questions.Add(new QuestionViewModel(numberOfInitialOptions));
            }
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Назва опитування є обов'язковою")]
        [MaxLength(100, ErrorMessage = "Максимальний обсяг назви - 100 символів")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Опис опитування є обов'язковим")]
        [MaxLength(500, ErrorMessage = "Максимальний обсяг опису - 500 символів")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Кінцевий час опитування є обов'язковим")]
        public DateTime StopDateTime { get; set; }

        public bool IsDeleted { get; set; }

        public List<QuestionViewModel> Questions { get; set; }

        public List<UserAnswerViewModel> Answers { get; set; }
    }
}
