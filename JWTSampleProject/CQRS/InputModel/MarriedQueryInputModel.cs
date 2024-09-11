using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class MarriedQueryInputModel : IRequest<Married>
    {
        public string MarriedName { get; set; }

    }
}
