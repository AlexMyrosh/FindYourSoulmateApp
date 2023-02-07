using System;
using System.Collections.Generic;

namespace Business_Logic_Layer.Models
{
    public class SurveyModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public IEnumerable<QuestionModel> Questions { get; set; }
    }
}
