namespace Domain.DTOs.GroupDTO;

public class GetGroupDto
{
    public int Id { get; set; }
    public string GroupName { get; set; } = null!;
    public string? Description { get; set; }
    public string? Status { get; set; }
    public int CourseId { get; set; }
}
