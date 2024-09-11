using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class ReligionQueryInputModel : IRequest<Person>
    {
        public string ReligionName { get; set; }

    }
}
