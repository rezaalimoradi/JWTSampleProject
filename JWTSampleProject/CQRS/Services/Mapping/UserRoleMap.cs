using AutoMapper;
using JWTSampleProject.Core.Commands;
using JWTSampleProject.Models;
using JWTSampleProject.Services.Dto;

namespace JWTSampleProject.CQRS.Services.Mapping
{
    public class UserRoleMap : Profile
    {
        public UserRoleMap()
        {
            CreateMap<UserRole, AddUserRoleCommand>().ForMember(a => a.Id, b => b.Ignore()).ReverseMap();
            CreateMap<UserRole, UserRoleDto>().ReverseMap();
        }
    }
}
