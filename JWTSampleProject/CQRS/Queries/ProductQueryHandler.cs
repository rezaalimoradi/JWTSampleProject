using AutoMapper;
using Infrastructure.Dto;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.CQRS.Queries
{
    public class ProductQueryHandler : IRequestHandler<ProductQueryInputModel, List<ProductDto>>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public ProductQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProductDto>> Handle(ProductQueryInputModel request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.ToListAsync();
            var res = _mapper.Map<List<ProductDto>>(product);
            return res;
        }
    }
}
