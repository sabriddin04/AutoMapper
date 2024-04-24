namespace Domain.Entities;

public class StudentGroup:BaseEntity
{
    public int StudentId { get; set; }
    public Student? Student { get; set; }
    public int GroupId { get; set; }
    public Group? Group { get; set; }
   
}