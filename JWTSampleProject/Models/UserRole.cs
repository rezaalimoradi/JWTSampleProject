namespace JWTSampleProject.Models
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public int RoleId { get; set; }
        public Guid UserId { get; set; }

    }
}
