using AutoMapper;
using BLL.Models;
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
        }
    }
}