using Domain.DTOs.MentorDTO;
using Domain.Responses;

namespace Infrastructure.Services.MentorService;

public interface IMentorService
{
    Task<Response<List<GetMentorDto>>> GetMentorsAsync();
    Task<Response<GetMentorDto>> GetMentorByIdAsync(int id);
    Task<Response<string>> CreateMentorAsync(AddMentorDto mentor);
    Task<Response<string>> UpdateMentorAsync(UpdateMentorDto mentor);
    Task<Response<bool>> DeleteMentorAsync(int id);
}
