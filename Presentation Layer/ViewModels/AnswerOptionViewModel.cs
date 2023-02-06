using System;

namespace Presentation_Layer.ViewModels
{
    public class AnswerOptionViewModel
    {
        public Guid Id { get; set; }

        public string OptionText { get; set; }

        public QuestionViewModel Question { get; set; }
    }
}
