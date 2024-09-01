using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.CQRS.Queries
{
    public class ProductByIdQueryHandler : IRequestHandler<ProductByIdQueryInputModel, Product>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public ProductByIdQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Product> Handle(ProductByIdQueryInputModel request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var res = _mapper.Map<Product>(product);
            return res;
        }
    }
}
