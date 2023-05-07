﻿using AutoMapper;
using BLL.Enums;
using BLL.Models;
using DAL.Enums;
using DAL.Models;
using PL.Enums;
using PL.Models;
using PL.ViewModels;

namespace PL.AutoMapper
{
    public class ModelsToViewModelsAutoMapper : Profile
    {
        public ModelsToViewModelsAutoMapper()
        {
            CreateMap<UserViewModel, UserModel>().ReverseMap();
            CreateMap<InterestViewModel, InterestModel>().ReverseMap();
            CreateMap<RegisterViewModel, UserViewModel>().ReverseMap();
            CreateMap<RegisterViewModel, UserModel>().ReverseMap();
            CreateMap<LoginViewModel, UserViewModel>().ReverseMap();
            CreateMap<LoginViewModel, UserModel>().ReverseMap();

            CreateMap<GenderViewModel, GenderModel>().ReverseMap();
            CreateMap<LookingForGenderViewModel, LookingForGenderModel>().ReverseMap();
            CreateMap<RelationTypeViewModel, RelationTypeModel>().ReverseMap();
        }
    }
}