using API.Dtos;
using API.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helper
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles ()
        {
            CreateMap<UserForRegisterDto, User > ();
            CreateMap<User, UserForDetailedDto>();
            CreateMap<UserForLoginDto, User>().ReverseMap();
        }
    }
}
