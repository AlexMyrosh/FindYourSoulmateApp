using System;

namespace Data_Access_Layer.Models
{
    public class AnswerOption
    {
        public Guid Id { get; set; }

        public string OptionText { get; set; }

        public Question Question { get; set; }
    }
}
