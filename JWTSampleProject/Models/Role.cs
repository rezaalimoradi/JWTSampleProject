using System.ComponentModel.DataAnnotations;

namespace JWTSampleProject.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [MaxLength(128), Required]
        public string RoleName { get; set; }
        public Guid UserId { get; set; }

    }
}
