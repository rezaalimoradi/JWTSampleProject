using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class RoleCurrentUserQueryInputModel : IRequest<Role>
    {

    }
}
