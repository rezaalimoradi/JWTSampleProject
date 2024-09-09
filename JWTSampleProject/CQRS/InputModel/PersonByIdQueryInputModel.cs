using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class PersonByIdQueryInputModel : IRequest<Person>
    {
        public int PersonId { get; set; }

    }
}
