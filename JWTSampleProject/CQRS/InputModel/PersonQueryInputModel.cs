using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class PersonQueryInputModel : IRequest<Person>
    {
        public string PersonName { get; set; }

    }
}
