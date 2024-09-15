using JWTSampleProject.Models;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dto;
public class ProductDto
{
    public Guid ProductId { get; set; }
    public bool IsAvailable { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string ProductName { get; set; }
    public DateTime ProductDate { get; set; }
    public Guid UserId { get; set; }

}