using System.ComponentModel.DataAnnotations;
using DAL.Enums;
using PL.Enums;

namespace PL.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(int numberOfAnswers)
        {
            Answers = new List<UserAnswerViewModel>(numberOfAnswers);
        }

        public UserViewModel(){}

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Ваше ім'я є обов'язковим")]
        [MaxLength(50, ErrorMessage = "Обсяг імені має бути не більшим ніж 50 символів")]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ваш нік в телеграмі є обов'язковим")]
        [MaxLength(50, ErrorMessage = "Нік має бути до 50 символів")]
        [Display(Name = "Телеграм/інстаграм (або інша соц. мережа)")]
        public string TelegramUsername { get; set; }

        [Required(ErrorMessage = "Ваш email є обов'язковим")]
        [EmailAddress(ErrorMessage = "Ой-ой, щось це не схоже на електронну скриньку")]
        [Display(Name = "Електронна скринька")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Вкажіть, будь-ласка, на якому ви зараз курсі")]
        [Range(1, 6, ErrorMessage = "Введіть число від 1 до 6")]
        [Display(Name = "На якому ти зараз курсі?")]
        public int UniversityYear { get; set; }

        [Required(ErrorMessage = "Вкажіть, будь-ласка, якої ви статі")]
        [Display(Name = "Стать")]
        public GenderViewModel Gender { get; set; }

        [Required(ErrorMessage = "Вкажіть, будь-ласка, яких людей ви хотіли би бачити в результаті")]
        [Display(Name = "Якої статі ти хотів би знайти людину?")]
        public LookingForGenderViewModel LookingForGender { get; set; }

        [Display(Name = "Я шукаю...")]
        public RelationTypeViewModel? LookingForRelationType { get; set; }

        [Required(ErrorMessage = "Вкажіть, будь-ласка, ваш факультет")]
        [Display(Name = "Твій факультет")]
        public UniversityFacultyViewModel UniversityFaculty { get; set; }

        [Display(Name = "В якому зараз ти місті? (не обов'язково)")]
        public string? City { get; set; }

        public Guid LastSurveyPass { get; set; }

        public bool IsDeleted { get; set; }

        public List<UserAnswerViewModel> Answers { get; set; }

    }
}
