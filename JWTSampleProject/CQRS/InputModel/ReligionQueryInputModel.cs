using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class ReligionQueryInputModel : IRequest<Religion>
    {
        public string ReligionName { get; set; }

    }
}
