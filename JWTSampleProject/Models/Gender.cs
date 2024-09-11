using System.ComponentModel.DataAnnotations;

namespace JWTSampleProject.Models
{
    public class Gender
    {
        [Key]
        [Required]
        public int GenderId { get; set; }
        [MaxLength(128), Required]
        public string GenderName { get; set; }

    }
}
