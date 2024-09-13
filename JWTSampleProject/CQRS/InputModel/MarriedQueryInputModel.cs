using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class MarriedQueryInputModel : IRequest<List<MarriedDto>>
    {
    }
}
