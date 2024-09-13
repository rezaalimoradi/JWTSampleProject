using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class GenderQueryInputModel : IRequest<List<GenderDto>>
    {
    }
}
