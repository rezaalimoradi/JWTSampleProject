using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class RoleByIdQueryInputModel : IRequest<User>
    {

        public Guid Id { get; set; }
    }
}
