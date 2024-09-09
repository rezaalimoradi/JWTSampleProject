using AutoMapper;
using JWTSampleProject.Core.Commands;
using JWTSampleProject.Models;
using JWTSampleProject.Services.Dto;


namespace JWTSampleProject.Services.Mapping
{
    public class RoleMap : Profile
    {
        public RoleMap()
        {
            CreateMap<Role, AddRoleCommand>().ForMember(a => a.RoleId, b => b.Ignore()).ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}
