using Domain.DTOs.GroupDTO;
using Domain.Responses;

namespace Infrastructure.Services.GroupService;

public interface IGroupService
{
     Task<Response<List<GetGroupDto>>>GetGroupsAsync();
    Task<Response<GetGroupDto>> GetGroupByIdAsync(int id);
    Task<Response<string>> CreateGroupAsync(AddGroupDto group);
    Task<Response<string>> UpdateGroupAsync(UpdateGroupDto group);
    Task<Response<bool>> DeleteGroupAsync(int id);
}
