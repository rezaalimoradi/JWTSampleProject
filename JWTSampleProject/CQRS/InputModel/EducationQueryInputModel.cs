using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class EducationQueryInputModel : IRequest<Education>
    {
        public string EducationName { get; set; }

    }
}
