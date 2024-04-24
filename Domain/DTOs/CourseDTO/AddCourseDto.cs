using Domain.Enums;

namespace Domain.DTOs;

public class AddCourseDto
{
    public string CourseName { get; set; } = null!;
    public string? Description { get; set; }
    public Status Status { get; set; }
}
