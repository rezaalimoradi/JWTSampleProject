using Infrastructure.Dto;
using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class ProductQueryInputModel : IRequest<List<ProductDto>>
    {
        public string ProductName { get; set; }
    }
}
