using System.Collections.Generic;
using System;

namespace Presentation_Layer.ViewModels
{
    public class SurveyViewModel
    {
        public SurveyViewModel() { }

        public SurveyViewModel(int numberOfOptions)
        {
            const int numberOfInitialOptions = 2;
            Questions = new List<QuestionViewModel>(numberOfOptions);
            for (var i = 0; i < Questions.Capacity; i++)
            {
                Questions.Add(new QuestionViewModel(numberOfInitialOptions));
            }
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime StopDateTime { get; set; }

        public UserViewModel User { get; set; }

        public List<QuestionViewModel> Questions { get; set; }
    }
}
