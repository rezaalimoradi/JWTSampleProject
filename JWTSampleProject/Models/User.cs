using System.ComponentModel.DataAnnotations;

namespace JWTSampleProject.Models
{
    public class User
    {
        [Key]
        [Required]
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        [MaxLength(128), Required]
        public string FirstName { get; set; }
        [MaxLength(128), Required]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Role> Roles { get; set; }
    }
}
