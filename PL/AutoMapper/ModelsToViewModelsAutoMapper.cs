﻿using AutoMapper;
using BLL.Enums;
using BLL.Models;
using PL.Enums;
using PL.ViewModels;

namespace PL.AutoMapper
{
    public class ModelsToViewModelsAutoMapper : Profile
    {
        public ModelsToViewModelsAutoMapper()
        {
            CreateMap<UpdateUserViewModel, UserModel>()
                .ForMember(dest => dest.FirstName, conf => conf.MapFrom(source => source.UserData.FirstName))
                .ForMember(dest => dest.LastName, conf => conf.MapFrom(source => source.UserData.LastName))
                .ForMember(dest => dest.Age, conf => conf.MapFrom(source => source.UserData.Age))
                .ForMember(dest => dest.BirthDate, conf => conf.MapFrom(source => source.UserData.BirthDate))
                .ForMember(dest => dest.Gender, conf => conf.MapFrom(source => source.UserData.Gender))
                .ForMember(dest => dest.Bio, conf => conf.MapFrom(source => source.UserData.Bio))
                .ForMember(dest => dest.LookingForGender, conf => conf.MapFrom(source => source.UserData.LookingForGender))
                .ForMember(dest => dest.RelationType, conf => conf.MapFrom(source => source.UserData.RelationType))
                .ForMember(dest => dest.Interests, conf => conf.MapFrom(source => source.SelectedInterests.Select(id =>
                    new InterestModel
                    {
                        Id = id
                    })))
                .ForMember(dest => dest.RegistrationDate, conf => conf.Ignore())
                .ForMember(dest => dest.LastLogin, conf => conf.Ignore())
                .ForMember(dest => dest.IsDeleted, conf => conf.Ignore())
                .ForMember(dest => dest.Id, conf => conf.Ignore())
                .ForMember(dest => dest.UserName, conf => conf.Ignore())
                .ForMember(dest => dest.NormalizedUserName, conf => conf.Ignore())
                .ForMember(dest => dest.Email, conf => conf.Ignore())
                .ForMember(dest => dest.NormalizedEmail, conf => conf.Ignore())
                .ForMember(dest => dest.EmailConfirmed, conf => conf.Ignore())
                .ForMember(dest => dest.PasswordHash, conf => conf.Ignore())
                .ForMember(dest => dest.SecurityStamp, conf => conf.Ignore())
                .ForMember(dest => dest.ConcurrencyStamp, conf => conf.Ignore())
                .ForMember(dest => dest.PhoneNumber, conf => conf.Ignore())
                .ForMember(dest => dest.PhoneNumberConfirmed, conf => conf.Ignore())
                .ForMember(dest => dest.TwoFactorEnabled, conf => conf.Ignore())
                .ForMember(dest => dest.LockoutEnd, conf => conf.Ignore())
                .ForMember(dest => dest.LockoutEnabled, conf => conf.Ignore())
                .ForMember(dest => dest.AccessFailedCount, conf => conf.Ignore());

            CreateMap<UserModel, UserViewModel>();
            CreateMap<InterestViewModel, InterestModel>().ReverseMap();
            CreateMap<RegisterViewModel, UserViewModel>().ReverseMap();
            CreateMap<RegisterViewModel, UserModel>().ReverseMap();
            CreateMap<LoginViewModel, UserViewModel>().ReverseMap();
            CreateMap<LoginViewModel, UserModel>().ReverseMap();
            CreateMap<ChatViewModel, ChatMessageModel>().ReverseMap();
            CreateMap<FeedbackViewModel, FeedbackModel>().ReverseMap();
            CreateMap<ChatMessageViewModel, ChatMessageModel>().ReverseMap();

            CreateMap<GenderViewModel, GenderModel>().ReverseMap();
            CreateMap<LookingForGenderViewModel, LookingForGenderModel>().ReverseMap();
            CreateMap<RelationTypeViewModel, RelationTypeModel>().ReverseMap();
            CreateMap<ContactViewModel, ContactModel>().ReverseMap();
        }
    }
}