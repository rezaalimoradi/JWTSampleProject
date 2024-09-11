using AutoMapper;
using Infrastructure.Dto;
using JWTSampleProject.Core.Commands;
using JWTSampleProject.Models;


namespace JWTSampleProject.Services.Mapping
{
    public class EducationMap : Profile
    {
        public EducationMap()
        {
            CreateMap<Education, AddEducationCommand>().ForMember(a => a.EducationId, b => b.Ignore()).ReverseMap();
            CreateMap<Education, EducationDto>().ReverseMap();
        }
    }
}
