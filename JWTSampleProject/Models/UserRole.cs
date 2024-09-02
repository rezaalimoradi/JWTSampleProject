namespace JWTSampleProject.Models
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }

    }
}
