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
            CreateMap<UserModel, User>()
                .ForMember(dest => dest.FirstName, conf => conf.MapFrom(source => source.FirstName))
                .ForMember(dest => dest.LastName, conf => conf.MapFrom(source => source.LastName))
                .ForMember(dest => dest.Age, conf => conf.MapFrom(source => source.Age))
                .ForMember(dest => dest.BirthDate, conf => conf.MapFrom(source => source.BirthDate))
                .ForMember(dest => dest.Gender, conf => conf.MapFrom(source => source.Gender))
                .ForMember(dest => dest.Bio, conf => conf.MapFrom(source => source.Bio))
                .ForMember(dest => dest.LookingForGender, conf => conf.MapFrom(source => source.LookingForGender))
                .ForMember(dest => dest.RelationType, conf => conf.MapFrom(source => source.RelationType));

            CreateMap<User, UserModel>();
            CreateMap<InterestModel, Interest>().ReverseMap();

            CreateMap<GenderModel, Gender>().ReverseMap();
            CreateMap<LookingForGenderModel, LookingForGender>().ReverseMap();
            CreateMap<RelationTypeModel, RelationType>().ReverseMap();
            CreateMap<ChatMessageModel, ChatMessage>().ReverseMap();
        }
    }
}