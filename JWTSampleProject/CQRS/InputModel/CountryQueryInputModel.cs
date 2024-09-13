using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class CountryQueryInputModel : IRequest<List<CountryDto>>
    {
    }
}
