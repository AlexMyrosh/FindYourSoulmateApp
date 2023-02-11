using System;
using System.Collections.Generic;

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

        public string Name { get; set; }

        public string TelegramUsername { get; set; }

        public string Email { get; set; }

        public Guid LastSurveyPass { get; set; }

        public bool IsDeleted { get; set; }

        public List<UserAnswerViewModel> Answers { get; set; }

    }
}
