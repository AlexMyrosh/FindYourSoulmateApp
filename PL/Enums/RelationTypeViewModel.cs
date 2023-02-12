using System.ComponentModel.DataAnnotations;

namespace PL.Enums;

public enum RelationTypeViewModel
{
    [Display(Name = "Друзів")]
    Friendship,
    [Display(Name = "Можливо кохання:)")]
    Relationship,
    [Display(Name = "Ще не визначився (-лась)")]
    Unknown
}