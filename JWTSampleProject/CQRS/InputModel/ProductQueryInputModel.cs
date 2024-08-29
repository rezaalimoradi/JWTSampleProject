using JWTSampleProject.Infrastructure.Base;
using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class ProductQueryInputModel : IRequest<string>
    {
        public string ProductName { get; set; }

    }
}
