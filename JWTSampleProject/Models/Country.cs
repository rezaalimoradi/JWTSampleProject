using System.ComponentModel.DataAnnotations;

namespace JWTSampleProject.Models
{
    public class Country
    {
        [Key]
        [Required]
        public int CountryId { get; set; }
        [Required]
        [MaxLength(128), Required]
        public string CountryName { get; set; }

    }
}
