using AutoMapper;
using FastStart.Entities;
using FastStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastStart
{
    public class UsersMappingProfile : Profile
    {
        public UsersMappingProfile()
        {
            CreateMap<Users, UsersDTO>();

            CreateMap<Roles, RolesDTO>()
                .ReverseMap();

            CreateMap<CreateUsersDTO, Users>();

        }
    }
}
