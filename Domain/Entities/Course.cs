using Domain.Enums;

namespace Domain.Entities;

public class Course:BaseEntity
{
    public string CourseName { get; set; } = null!;
    public string? Description { get; set; }
    public Status Status { get; set; }
    public List<Group>? Groups { get; set; }
}