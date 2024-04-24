using System.Data.Common;
using System.Net;
using AutoMapper;
using Domain.DTOs.GroupDTO;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Services.GroupService;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.StudentService;

public class GroupService : IGroupService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public GroupService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    #region GetGroupsAsync

    public async Task<Response<List<GetGroupDto>>> GetGroupsAsync()
    {
        try
        {
            var groups = await _context.Groups.ToListAsync();
            var mapped = _mapper.Map<List<GetGroupDto>>(groups);
            return new Response<List<GetGroupDto>>(mapped);
        }
        catch (DbException dbEx)
        {
            return new Response<List<GetGroupDto>>(HttpStatusCode.InternalServerError, dbEx.Message);
        }
        catch (Exception ex)
        {
            return new Response<List<GetGroupDto>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    #endregion

    #region GetGroupByIdAsync

    public async Task<Response<GetGroupDto>> GetGroupByIdAsync(int id)
    {
        try
        {
            var group = await _context.Groups.FirstOrDefaultAsync(x => x.Id == id);
            if (group == null)
                return new Response<GetGroupDto>(HttpStatusCode.BadRequest, "group not found");
            var mapped = _mapper.Map<GetGroupDto>(group);

            return new Response<GetGroupDto>(mapped);
        }
        catch (Exception e)
        {
            return new Response<GetGroupDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    #endregion

    #region CreateGroupAsync

    public async Task<Response<string>> CreateGroupAsync(AddGroupDto addGroupDto)
    {
        try
        {
            var existing = await _context.Groups.FirstOrDefaultAsync(x => x.GroupName == addGroupDto.GroupName);
            if (existing != null)
                return new Response<string>(HttpStatusCode.BadRequest, "group already exists");
            var mapped = _mapper.Map<Group>(existing);

            await _context.Groups.AddAsync(mapped);
            await _context.SaveChangesAsync();

            return new Response<string>("Successfully created a new group");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    #endregion

    #region UpdateGroupAsync

    public async Task<Response<string>> UpdateGroupAsync(UpdateGroupDto updateGroupDto)
    {
        try
        {
            var mapped = _mapper.Map<Group>(updateGroupDto);
            _context.Groups.Update(mapped);
            var update = await _context.SaveChangesAsync();
            if (update == 0) return new Response<string>(HttpStatusCode.BadRequest, "Group not found");
            return new Response<string>(" Group updated successfully");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    #endregion

    #region DeleteGroupAsync
    public async Task<Response<bool>> DeleteGroupAsync(int id)
    {
        try
        {
            var group = await _context.Courses.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (group == 0)
                return new Response<bool>(HttpStatusCode.BadRequest, "Group not found");

            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
    #endregion
}
