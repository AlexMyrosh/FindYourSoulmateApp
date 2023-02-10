using System;

namespace Presentation_Layer.ViewModels
{
    public class UserAnswerViewModel
    {
        public Guid Id { get; set; }

        public string Answer { get; set; }

        public UserViewModel User { get; set; }

        public QuestionViewModel Question { get; set; }
    }
}
