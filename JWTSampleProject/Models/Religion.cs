using System.ComponentModel.DataAnnotations;

namespace JWTSampleProject.Models
{
    public class Religion
    {
        [Key]
        [Required]
        public int ReligionId { get; set; }
        [MaxLength(128), Required]
        public string ReligionName { get; set; }

    }
}
