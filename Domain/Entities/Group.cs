using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities;

public class Group:BaseEntity
{
    public string GroupName { get; set; } = null!;
    public string? Description { get; set; }
    public Status Status { get; set; }
    [ForeignKey("CourseId")]
    public int CourseId { get; set; }
    public Course? Course { get; set; }
    public List<StudentGroup>? StudentGroups { get; set; }
    public List<MentorGroup>? MentorGroups { get; set; }
   
}