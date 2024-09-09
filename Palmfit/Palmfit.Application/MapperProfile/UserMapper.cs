

using AutoMapper;
using Palmfit.Application.Dtos.User;
using Palmfit.Domain.Entities.Users;

namespace Palmfit.Application.MapperProfile
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<Register, AppUser>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.AcceptsTerms, opt => opt.Ignore());

            CreateMap<AppUser, Register>();


            // New mapping for UserDto
            CreateMap<AppUser, UserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src=>src.UserName))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.Timezone, opt => opt.MapFrom(src => src.Timezone))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height))
                .ForMember(dest => dest.HeightUnit, opt => opt.MapFrom(src => src.HeightUnit))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
                .ForMember(dest => dest.WeightUnit, opt => opt.MapFrom(src => src.WeightUnit))
                .ForMember(dest => dest.ActivityLevel, opt => opt.MapFrom(src => src.ActivityLevel))
                .ForMember(dest => dest.FitnessLevel, opt => opt.MapFrom(src => src.FitnessLevel))
                .ForMember(dest => dest.WeightGoal, opt => opt.MapFrom(src => src.WeightGoal))
                .ForMember(dest => dest.SubscriptionPlan, opt => opt.MapFrom(src => src.SubscriptionPlan))
                .ForMember(dest => dest.SubscriptionExpiry, opt => opt.MapFrom(src => src.SubscriptionExpiry))
                .ForMember(dest => dest.AccountStatus, opt => opt.MapFrom(src => src.AccountStatus))
                .ForMember(dest => dest.OnlineStatus, opt => opt.MapFrom(src => src.OnlineStatus))
                .ForMember(dest => dest.LastLogin, opt => opt.MapFrom(src => src.LastLogin));


            //CreateMap<AppUser, UpdateUser>()
            //    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            //    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            //    .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
            //    .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
            //    .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            //    .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
            //    .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
            //    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            //    .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Height))
            //    .ForMember(dest => dest.HeightUnit, opt => opt.MapFrom(src => src.HeightUnit))
            //    .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
            //    .ForMember(dest => dest.WeightUnit, opt => opt.MapFrom(src => src.WeightUnit))
            //    .ForMember(dest => dest.ActivityLevel, opt => opt.MapFrom(src => src.ActivityLevel))
            //    .ForMember(dest => dest.FitnessLevel, opt => opt.MapFrom(src => src.FitnessLevel))
            //    .ForMember(dest => dest.WeightGoal, opt => opt.MapFrom(src => src.WeightGoal))
            //    .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            //    .ForMember(dest => dest.Email, opt => opt.Ignore())
            //    .ForMember(dest => dest.Image, opt => opt.Ignore());
             
        }
    }
}
