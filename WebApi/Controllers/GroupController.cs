
using Domain.DTOs.GroupDTO;
using Domain.Responses;
using Infrastructure.Services.GroupService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("[controller]")]
[ApiController]
public class GroupController(IGroupService groupService):ControllerBase
{

    [HttpGet("get-Groups")]
    public async Task<Response<List<GetGroupDto>>> GetGroupsAsync()
    {
        return await groupService.GetGroupsAsync();
    }
    [HttpGet("{GroupId:int}")]
    public async Task<Response<GetGroupDto>> GetGroupByIdAsync(int id)
    {
        return await groupService.GetGroupByIdAsync(id);
    }
    
    [HttpPost("create-group")]
    public async Task<Response<string>> AddGroupAsync(AddGroupDto addGroupDto )
    {
        return await groupService.CreateGroupAsync(addGroupDto);
    }
    
    [HttpPut("update-group")]
    public async Task<Response<string>> UpdateGroupAsync(UpdateGroupDto updateGroupDto)
    {
        return await groupService.UpdateGroupAsync(updateGroupDto);
    }
    
    [HttpDelete("{GroupId:int}")]
    public async Task<Response<bool>> DeleteGroupAsync(int id)
    {
        return await groupService.DeleteGroupAsync(id);
    }
    
}

