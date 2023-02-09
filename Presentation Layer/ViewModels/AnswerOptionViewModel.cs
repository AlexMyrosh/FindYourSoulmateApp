using System;

namespace Presentation_Layer.ViewModels
{
    public class AnswerOptionViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string OptionText { get; set; }

        public bool IsSelected { get; set; }

        public QuestionViewModel Question { get; set; }
    }
}
