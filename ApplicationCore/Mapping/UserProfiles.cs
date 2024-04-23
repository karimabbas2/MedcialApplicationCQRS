using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.User.Commands.Register;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<RegisterCommand, ApplicationDomain.User>()
             .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.FullName));
        }

    }
}