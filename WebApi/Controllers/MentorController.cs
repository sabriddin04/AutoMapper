using Domain.DTOs.MentorDTO;
using Domain.Responses;
using Infrastructure.Services.MentorService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("[controller]")]
[ApiController]
public class MentorController:ControllerBase
{
    private readonly IMentorService _mentorService;

    public MentorController(IMentorService mentorService)
    {
        _mentorService = mentorService;
    }

    [HttpGet("get-mentors")]
    public async Task<Response<List<GetMentorDto>>> GetMentorsAsync()
    {
        return await _mentorService.GetMentorsAsync();
    }
    [HttpGet("{mentor-Id:int}")]
    public async Task<Response<GetMentorDto>> GetMentorByIdAsync(int id)
    {
        return await _mentorService.GetMentorByIdAsync(id);
    }
    
    [HttpPost("create-mentor")]
    public async Task<Response<string>> AddMentorAsync(AddMentorDto addMentorDto)
    {
        return await _mentorService.CreateMentorAsync(addMentorDto);
    }
    
    [HttpPut("update-mentor")]
    public async Task<Response<string>> UpdateMentorAsync(UpdateMentorDto updateMentorDto)
    {
        return await _mentorService.UpdateMentorAsync(updateMentorDto);
    }
    
    [HttpDelete("{mentorId:int}")]
    public async Task<Response<bool>> DeleteMentorAsync(int id)
    {
        return await _mentorService.DeleteMentorAsync(id);
    }
     
}
