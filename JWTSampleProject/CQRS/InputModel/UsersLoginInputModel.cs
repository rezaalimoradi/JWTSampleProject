using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class UsersLoginInputModel : IRequest<List<User>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
