namespace JWTSampleProject.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public bool IsAvailable { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ProductName { get; set; }
        public DateTime ProductDate { get; set; }
    }
}
