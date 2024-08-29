using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class ProductQueryInputModel : IRequest<Product>
    {
        public string ProductName { get; set; }

    }
}
