namespace BLL.Models
{
    public class AnswerOptionModel
    {
        public Guid Id { get; set; }

        public string OptionText { get; set; }

        public QuestionModel Question { get; set; }
    }
}
