using AutoMapper;
using Business_Logic_Layer.Models;
using Data_Access_Layer.Models;

namespace Business_Logic_Layer.AutoMapper
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