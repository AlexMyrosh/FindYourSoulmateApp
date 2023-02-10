using System;

namespace Business_Logic_Layer.Models
{
    public class UserAnswerModel
    {
        public Guid Id { get; set; }

        public string Answer { get; set; }

        public UserModel User { get; set; }

        public QuestionModel Question { get; set; }
    }
}
