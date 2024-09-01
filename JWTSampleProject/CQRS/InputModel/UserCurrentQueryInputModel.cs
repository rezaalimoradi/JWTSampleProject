using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class UserCurrentQueryInputModel : IRequest<User>
    {

    }
}
