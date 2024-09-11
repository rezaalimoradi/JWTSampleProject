using AutoMapper;
using Infrastructure.Dto;
using JWTSampleProject.Core.Commands;
using JWTSampleProject.Models;


namespace JWTSampleProject.Services.Mapping
{
    public class CountryMap : Profile
    {
        public CountryMap()
        {
            CreateMap<Country, AddCountryCommand>().ForMember(a => a.CountryId, b => b.Ignore()).ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
        }
    }
}
