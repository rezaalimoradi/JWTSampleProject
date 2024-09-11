using System.ComponentModel.DataAnnotations;

namespace JWTSampleProject.Models
{
    public class Province
    {
        [Key]
        [Required]
        public int ProvinceId { get; set; }
        [MaxLength(128), Required]
        public string ProvinceName { get; set; }
    }
}
