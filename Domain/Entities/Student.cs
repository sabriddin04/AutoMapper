using Domain.Enums;

namespace Domain.Entities;

public class Student:BaseEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public Status Status { get; set; }
    public Gender Gender { get; set; }
    public DateTime DoB { get; set; }
    public List<StudentGroup>? StudentGroups { get; set; }
}