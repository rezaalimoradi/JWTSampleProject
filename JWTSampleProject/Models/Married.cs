using System.ComponentModel.DataAnnotations;

namespace JWTSampleProject.Models
{
    public class Married
    {
        [Key]
        [Required]
        public int MarriedId { get; set; }
        [MaxLength(128), Required]
        public string MarriedName { get; set; }
    }
}
