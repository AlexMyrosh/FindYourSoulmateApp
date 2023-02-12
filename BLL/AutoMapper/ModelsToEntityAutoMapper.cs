using AutoMapper;
using BLL.Models;
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
        }
    }
}