using AutoMapper;
using Business_Logic_Layer.Models;
using Presentation_Layer.ViewModels;

namespace Presentation_Layer.AutoMapper
{
    public class ModelsToViewModelsAutoMapper : Profile
    {
        public ModelsToViewModelsAutoMapper()
        {
            CreateMap<QuestionViewModel, QuestionModel>().ReverseMap();
            CreateMap<AnswerOptionViewModel, AnswerOptionModel>().ReverseMap();
            CreateMap<SurveyViewModel, SurveyModel>().ReverseMap();
        }
    }
}