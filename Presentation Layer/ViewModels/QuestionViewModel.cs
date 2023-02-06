using System;
using System.Collections.Generic;

namespace Presentation_Layer.ViewModels
{
    public class QuestionViewModel
    {
        public QuestionViewModel() { }

        public QuestionViewModel(int numberOfOptions)
        {
            Options = new List<AnswerOptionViewModel>(numberOfOptions);
            for (var i = 0; i < Options.Capacity; i++)
            {
                Options.Add(new AnswerOptionViewModel());
            }
        }

        public Guid Id { get; set; }

        public string Body { get; set; }

        public double Coefficient { get; set; }

        public bool IsDeleted { get; set; }

        public List<AnswerOptionViewModel> Options { get; set; }
    }
}
