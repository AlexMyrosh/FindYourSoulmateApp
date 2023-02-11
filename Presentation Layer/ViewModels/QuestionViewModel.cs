using Business_Logic_Layer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Поле з питанням є обов'язковим")]
        [MaxLength(500, ErrorMessage = "Максимальний обсяг питання - 500 символів")]
        public string Body { get; set; }

        [Required(ErrorMessage = "Коефіціент є обов'язковим")]
        [Range(0.2, 1, ErrorMessage = "Коефіціент має бути в межах від 0.2 до 1")]
        public double Coefficient { get; set; }

        public bool IsDeleted { get; set; }

        public SurveyViewModel Survey { get; set; }

        public List<UserAnswerViewModel> UserAnswers { get; set; }

        public List<AnswerOptionViewModel> Options { get; set; }
    }
}
