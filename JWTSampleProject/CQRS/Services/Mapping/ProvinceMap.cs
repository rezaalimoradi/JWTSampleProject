using AutoMapper;
using JWTSampleProject.Core.Commands;
using JWTSampleProject.Models;
using JWTSampleProject.Services.Dto;


namespace JWTSampleProject.Services.Mapping
{
    public class ProvinceMap : Profile
    {
        public ProvinceMap()
        {
            CreateMap<Province, AddProvinceCommand>().ForMember(a => a.ProvinceId, b => b.Ignore()).ReverseMap();
            CreateMap<Province, ProvinceDto>().ReverseMap();
        }
    }
}
