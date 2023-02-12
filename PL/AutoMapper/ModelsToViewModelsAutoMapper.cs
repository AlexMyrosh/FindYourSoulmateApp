using AutoMapper;
using BLL.Enums;
using BLL.Models;
using DAL.Enums;
using PL.Enums;
using PL.ViewModels;

namespace PL.AutoMapper
{
    public class ModelsToViewModelsAutoMapper : Profile
    {
        public ModelsToViewModelsAutoMapper()
        {
            CreateMap<QuestionViewModel, QuestionModel>().ReverseMap();
            CreateMap<AnswerOptionViewModel, AnswerOptionModel>().ReverseMap();
            CreateMap<SurveyViewModel, SurveyModel>().ReverseMap();
            CreateMap<UserViewModel, UserModel>().ReverseMap();
            CreateMap<UserAnswerViewModel, UserAnswerModel>().ReverseMap();
            CreateMap<LookingForGenderViewModel, LookingForGenderModel>().ReverseMap();
            CreateMap<GenderViewModel, GenderModel>().ReverseMap();
            CreateMap<RelationTypeViewModel, RelationTypeModel>().ReverseMap();
            CreateMap<UniversityFacultyViewModel, UniversityFacultyModel>().ReverseMap();
        }
    }
}