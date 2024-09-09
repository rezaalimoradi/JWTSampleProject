using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class UserRoleByIdQueryInputModel : IRequest<UserRole>
    {

        public int UserRoleId { get; set; }
    }
}
