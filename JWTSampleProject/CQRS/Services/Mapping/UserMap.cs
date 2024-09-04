using AutoMapper;
using Infrastructure.Dto;
using JWTSampleProject.Core.Commands;
using JWTSampleProject.Models;


namespace JWTSampleProject.Services.Mapping
{
    public class UserMap : Profile
    {
        public UserMap()
        {
            CreateMap<User, AddUserCommand>().ForMember(a => a.Id, b => b.Ignore()).ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
