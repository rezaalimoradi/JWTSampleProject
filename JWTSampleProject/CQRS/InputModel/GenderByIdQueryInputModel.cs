using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class GenderByIdQueryInputModel : IRequest<Gender>
    {
        public int GenderId { get; set; }

    }
}
