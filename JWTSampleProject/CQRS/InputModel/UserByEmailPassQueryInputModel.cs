using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class UserByEmailPassQueryInputModel : IRequest<User>
    {

        public string Email { get; set; }
        public string PassWord { get; set; }
    }
}
