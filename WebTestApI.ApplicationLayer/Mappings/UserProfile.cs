using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.ApplicationLayer.Dtos;
using WebTestApI.CoreLayer.Entity;

namespace WebTestApI.ApplicationLayer.Mappings
{
   public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserRegisterDto>()

                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber.Value))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
                .ForMember(dest => dest.NationalCode, opt => opt.MapFrom(src => src.NationalCode.Value))
                .ForMember(dest => dest.Password, opt => opt.Ignore()); // Never map Password out

            CreateMap<UserRegisterDto, User>(); // برای ایجاد کردن کاربر جدید از DTO (Registration)
        }
    }
}

