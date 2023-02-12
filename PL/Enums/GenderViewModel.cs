using System.ComponentModel.DataAnnotations;

namespace PL.Enums;

public enum GenderViewModel
{
    [Display(Name = "Хлопець")]
    Male,
    [Display(Name = "Дівчина")]
    Female,
}