using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class CountryByIdQueryInputModel : IRequest<Country>
    {
        public int CountryId { get; set; }

    }
}
