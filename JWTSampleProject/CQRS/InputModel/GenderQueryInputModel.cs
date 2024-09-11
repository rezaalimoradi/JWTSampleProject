using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class GenderQueryInputModel : IRequest<Gender>
    {
        public string GenderName { get; set; }

    }
}
