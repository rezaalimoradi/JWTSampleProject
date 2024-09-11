using AutoMapper;
using Infrastructure.Dto;
using JWTSampleProject.Core.Commands;
using JWTSampleProject.Models;


namespace JWTSampleProject.Services.Mapping
{
    public class GenderMap : Profile
    {
        public GenderMap()
        {
            CreateMap<Gender, AddGenderCommand>().ForMember(a => a.GenderId, b => b.Ignore()).ReverseMap();
            CreateMap<Gender, GenderDto>().ReverseMap();
        }
    }
}
