namespace Domain.DTOs.MentorDTO;

public class GetMentorDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Status { get; set; }
    public string? Gender { get; set; }
    public DateTime DoB { get; set; }
}
