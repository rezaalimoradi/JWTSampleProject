using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class UserRoleQueryInputModel : IRequest<List<UserRole>>
    {
        

    }
}
