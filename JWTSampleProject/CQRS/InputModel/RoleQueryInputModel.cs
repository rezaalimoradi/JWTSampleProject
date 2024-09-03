using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class RoleQueryInputModel : IRequest<List<Role>>
    {
        

    }
}
