using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class UserQueryInputModel : IRequest<User>
    {
        public string UserName { get; set; }

    }
}
