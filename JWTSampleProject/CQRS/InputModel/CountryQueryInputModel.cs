using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class CountryQueryInputModel : IRequest<Person>
    {
        public string CountryName { get; set; }

    }
}
