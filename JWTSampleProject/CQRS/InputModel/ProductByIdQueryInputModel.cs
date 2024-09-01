using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class ProductByIdQueryInputModel : IRequest<Product>
    {
        public Guid Id { get; set; }

    }
}
