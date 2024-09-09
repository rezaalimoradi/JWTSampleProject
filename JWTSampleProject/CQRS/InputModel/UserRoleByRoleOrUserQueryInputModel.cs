using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class UserRoleByRoleOrUserQueryInputModel : IRequest<UserRole>
    {
        public int RoleId { get; set; }
        public Guid UserId { get; set; }
    }
}
