using Domain.Enums;

namespace Domain.DTOs.GroupDTO;

public class AddGroupDto
{
    public string GroupName { get; set; } = null!;
    public string? Description { get; set; }
    public Status Status { get; set; }
    public int CourseId { get; set; }
}
