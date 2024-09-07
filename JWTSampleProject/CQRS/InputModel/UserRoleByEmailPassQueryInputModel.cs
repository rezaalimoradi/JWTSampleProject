using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class UserRoleByEmailPassQueryInputModel : IRequest<UserRole>
    {

        public int UserRoleId { get; set; }
        public int RoleId { get; set; }
        public Guid UserId { get; set; }
    }
}
