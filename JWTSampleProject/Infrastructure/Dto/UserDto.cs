﻿namespace Infrastructure.Dto;
public class UserDto
{
    public Guid UserId { get; set; }
    public bool IsActive { get; set; }
    public string Email { get; set; }
    public string PassWord { get; set; }
    public string Role { get; set; }
    public string Phone { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public List<int> Roles { get; set; }
}