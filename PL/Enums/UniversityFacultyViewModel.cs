using System.ComponentModel.DataAnnotations;

namespace PL.Enums;

public enum UniversityFacultyViewModel
{
    [Display(Name = "Факультет економіки і права")]
    FacultyOfEconomicsAndLaw,
    [Display(Name = "Факультет інформаційних технологій")]
    FacultyOfInformationTechnologies,
    [Display(Name = "Факультет менеджменту і маркетингу")]
    FacultyOfManagementAndMarketing,
    [Display(Name = "Факультет міжнародних відносин і журналістики")]
    FacultyOfInternationalRelationsAndJournalism,
    [Display(Name = "Факультет мiжнародної економiки і підприємництва")]
    FacultyOfInternationalEconomyAndEntrepreneurship,
    [Display(Name = "Факультет фінансів і обліку")]
    FacultyOfFinanceAndAccounting,
    [Display(Name = "Факультет підготовки іноземних громадян")]
    FacultyOfTrainingOfForeignCitizens,
    [Display(Name = "Післядипломна освіта та підвищення кваліфікації викладачів")]
    PostgraduateEducationAndProfessionalDevelopmentOfTeachers
}