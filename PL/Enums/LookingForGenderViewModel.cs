using System.ComponentModel.DataAnnotations;

namespace PL.Enums;

public enum LookingForGenderViewModel
{
    [Display(Name = "Хлопець")]
    Male,
    [Display(Name = "Дівчина")]
    Female,
    [Display(Name = "Не має різниці")]
    Unknown
}