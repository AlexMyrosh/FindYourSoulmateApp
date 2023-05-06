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
            CreateMap<UserModel, User>().ReverseMap();
            
            CreateMap<GenderModel, Gender>().ReverseMap();
            CreateMap<InterestModel, Interest>().ReverseMap();
            CreateMap<LookingForGenderModel, LookingForGender>().ReverseMap();
            CreateMap<RelationTypeModel, RelationType>().ReverseMap();
        }
    }
}