using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class ReligionByIdQueryInputModel : IRequest<Religion>
    {
        public int ReligionId { get; set; }

    }
}
