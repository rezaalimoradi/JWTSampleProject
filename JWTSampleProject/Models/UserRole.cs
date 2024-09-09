using System.ComponentModel.DataAnnotations;

namespace JWTSampleProject.Models
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }
        public int RoleId { get; set; }
        public Guid UserId { get; set; }

    }
}
