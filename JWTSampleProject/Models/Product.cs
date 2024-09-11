using System.ComponentModel.DataAnnotations;

namespace JWTSampleProject.Models
{
    public class Product
    {
        [Key]
        [Required]
        public Guid ProductId { get; set; }
        public bool IsAvailable { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [MaxLength(128), Required]
        public string ProductName { get; set; }
        public DateTime ProductDate { get; set; }
        public Guid UserId { get; set; }


    }
}
