using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class EducationByIdQueryInputModel : IRequest<Education>
    {
        public int EducationId { get; set; }

    }
}
