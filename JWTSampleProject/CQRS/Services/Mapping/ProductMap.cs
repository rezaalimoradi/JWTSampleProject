using AutoMapper;
using Infrastructure.Dto;
using JWTSampleProject.Core.Commands;
using JWTSampleProject.Models;


namespace JWTSampleProject.Services.Mapping
{
    public class ProductMap : Profile
    {
        public ProductMap()
        {
            CreateMap<Product, AddProductCommand>().ForMember(a => a.ProductId, b => b.Ignore()).ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
