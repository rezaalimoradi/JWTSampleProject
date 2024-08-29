using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Infrastructure.Base;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace JWTSampleProject.CQRS.Queries
{
    public class ProductQueryHandler : IRequestHandler<ProductQueryInputModel, string>
    {
        public async Task<string> Handle(ProductQueryInputModel request, CancellationToken cancellationToken)
        {
            await Task.FromResult(0);
            var product = new Product();
            product.ProductName = request.ProductName;


            return "Hello" + request.ProductName;
        }
    }
}
