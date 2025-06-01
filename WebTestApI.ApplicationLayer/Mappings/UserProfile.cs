using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTestApI.ApplicationLayer.Dtos;
using WebTestApI.CoreLayer.Entity;
using WebTestApI.CoreLayer.ValueObjects;

namespace WebTestApI.ApplicationLayer.Mappings
{
   public class UserProfile:Profile
    {

            public UserProfile()
            {
                // User -> UserDto mapping (read)
                CreateMap<User, UserDto>()
                    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber.Value))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
                    .ForMember(dest => dest.NationalCode, opt => opt.MapFrom(src => src.NationalCode.Value))
                    .ForMember(dest => dest.Password, opt => opt.Ignore()); // Never expose password

            // UserDto -> User mapping (create)
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => PhoneNumber.Create(src.PhoneNumber)))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => Email.Create(src.Email)))
                .ForMember(dest => dest.NationalCode, opt => opt.MapFrom(src => NationalCode.Create(src.NationalCode)));
                    

                // Derived DTOs
                CreateMap<StudentRegisterDto, User>().IncludeBase<UserDto, User>();
                CreateMap<CoachRegisterDto, User>().IncludeBase<UserDto, User>();
            }
        }
    }



