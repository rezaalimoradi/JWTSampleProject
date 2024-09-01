using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.CQRS.Queries
{
    public class ProductQueryHandler : IRequestHandler<ProductQueryInputModel, Product>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public ProductQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Product> Handle(ProductQueryInputModel request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstAsync();
            var res = _mapper.Map<Product>(product);
            return res;
        }
    }
}
