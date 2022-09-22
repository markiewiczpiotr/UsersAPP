using AutoMapper;
using FastStart.Entities;
using FastStart.Models;

namespace FastStart
{
    public class UsersMappingProfile : Profile
    {
        public UsersMappingProfile()
        {
            CreateMap<Users, UsersDTO>();

            CreateMap<CreateUsersDTO, Users>();

        }
    }
}
