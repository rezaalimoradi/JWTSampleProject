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
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public ProductQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Product> Handle(ProductQueryInputModel request, CancellationToken cancellationToken)
        {
            var newProduct = _mapper.Map<ProductQueryInputModel, Product>(request);
            await _context.Products.AnyAsync();
            return newProduct;
        }
    }
}
