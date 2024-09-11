using System.ComponentModel.DataAnnotations;

namespace JWTSampleProject.Models
{
    public class Person
    {
        [Key]
        [Required]
        public int PersonId { get; set; }
        [MaxLength(128), Required]
        public string PersonName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
