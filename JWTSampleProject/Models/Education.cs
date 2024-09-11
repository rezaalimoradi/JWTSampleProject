using System.ComponentModel.DataAnnotations;

namespace JWTSampleProject.Models
{
    public class Education
    {
        [Key]
        [Required]
        public int EducationId { get; set; }
        [MaxLength(128), Required]
        public string EducationName { get;}
    }
}
