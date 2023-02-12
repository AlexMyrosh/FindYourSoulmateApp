using System;

namespace Business_Logic_Layer.Models
{
    public class AnswerOptionModel
    {
        public Guid Id { get; set; }

        public string OptionText { get; set; }

        public QuestionModel Question { get; set; }
    }
}
