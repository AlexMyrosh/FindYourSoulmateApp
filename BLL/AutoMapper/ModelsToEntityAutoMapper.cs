using AutoMapper;
using BLL.Enums;
using BLL.Models;
using DAL.Enums;
using DAL.Models;

namespace BLL.AutoMapper
{
    public class ModelsToEntityAutoMapper : Profile
    {
        public ModelsToEntityAutoMapper()
        {
            CreateMap<QuestionModel, Question>().ReverseMap();
            CreateMap<AnswerOptionModel, AnswerOption>().ReverseMap();
            CreateMap<SurveyModel, Survey>().ReverseMap();
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<UserAnswerModel, UserAnswer>().ReverseMap();
            CreateMap<LookingForGenderModel, LookingForGender>().ReverseMap();
            CreateMap<GenderModel, Gender>().ReverseMap();
            CreateMap<RelationTypeModel, RelationType>().ReverseMap();
            CreateMap<UniversityFacultyModel, UniversityFaculty>().ReverseMap();
        }
    }
}