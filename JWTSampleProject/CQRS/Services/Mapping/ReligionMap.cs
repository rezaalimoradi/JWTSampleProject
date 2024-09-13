using AutoMapper;
using JWTSampleProject.Core.Commands;
using JWTSampleProject.Models;
using JWTSampleProject.Services.Dto;


namespace JWTSampleProject.Services.Mapping
{
    public class ReligionMap : Profile
    {
        public ReligionMap()
        {
            CreateMap<Religion, AddReligionCommand>().ForMember(a => a.ReligionId, b => b.Ignore()).ReverseMap();
            CreateMap<Religion, ReligionDto>().ReverseMap();
        }
    }
}
