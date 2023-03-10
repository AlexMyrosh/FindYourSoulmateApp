using System;
using System.Collections.Generic;

namespace Business_Logic_Layer.Models
{
    public class QuestionModel
    {
        public Guid Id { get; set; }

        public string Body { get; set; }

        public double Coefficient { get; set; }

        public bool IsDeleted { get; set; }

        public SurveyModel Survey { get; set; }

        public List<UserAnswerModel> UserAnswers { get; set; }

        public List<AnswerOptionModel> Options { get; set; }
    }
}
