using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class MarriedByIdQueryInputModel : IRequest<Married>
    {
        public int MarriedId { get; set; }

    }
}
