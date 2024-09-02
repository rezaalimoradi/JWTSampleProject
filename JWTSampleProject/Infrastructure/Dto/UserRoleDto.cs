namespace JWTSampleProject.Infrastructure.Dto
{
    public class UserRoleDto
    {
        public int UserRoleId { get; set; }
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
    }
}
