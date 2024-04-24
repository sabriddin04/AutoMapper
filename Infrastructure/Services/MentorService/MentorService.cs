using System.Data.Common;
using System.Net;
using AutoMapper;
using Domain.DTOs.MentorDTO;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Services.MentorService;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.StudentService;

public class MentorService : IMentorService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public MentorService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    #region GetMentorsAsync

    public async Task<Response<List<GetMentorDto>>> GetMentorsAsync()
    {
        try
        {
            var mentors = await _context.Mentors.ToListAsync();
            var mapped = _mapper.Map<List<GetMentorDto>>(mentors);
            return new Response<List<GetMentorDto>>(mapped);
        }
        catch (DbException dbEx)
        {
            return new Response<List<GetMentorDto>>(HttpStatusCode.InternalServerError, dbEx.Message);
        }
        catch (Exception ex)
        {
            return new Response<List<GetMentorDto>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    #endregion

    #region GetMentorByIdAsync

    public async Task<Response<GetMentorDto>> GetMentorByIdAsync(int id)
    {
        try
        {
            var mentor = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (mentor == null)
                return new Response<GetMentorDto>(HttpStatusCode.BadRequest, "Mentor not found");
            var mapped = _mapper.Map<GetMentorDto>(mentor);
            return new Response<GetMentorDto>(mapped);
        }
        catch (Exception e)
        {
            return new Response<GetMentorDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    #endregion

    #region CreateMentorAsync

    public async Task<Response<string>> CreateMentorAsync(AddMentorDto mentorDto)
    {
        try
        {
            var existing = await _context.Mentors.FirstOrDefaultAsync(x => x.Email == mentorDto.Email);
            if (existing != null)
                return new Response<string>(HttpStatusCode.BadRequest, "Mentor already exists");
            var mapped = _mapper.Map<Mentor>(mentorDto);

            await _context.Mentors.AddAsync(mapped);
            await _context.SaveChangesAsync();

            return new Response<string>("Successfully created a new mentor");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    #endregion

    #region UpdateMentorAsync

    public async Task<Response<string>> UpdateMentorAsync(UpdateMentorDto mentorDto)
    {
        try
        {
            var mapped = _mapper.Map<Mentor>(mentorDto);
            _context.Mentors.Update(mapped);
            var update= await _context.SaveChangesAsync();
            if(update==0)  return new Response<string>(HttpStatusCode.BadRequest, "Mentor not found");
            return new Response<string>("Mentor updated successfully");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    #endregion

    #region DeleteMentorAsync
    public async Task<Response<bool>> DeleteMentorAsync(int id)
    {
        try
        {
            var mentor = await _context.Mentors.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (mentor == 0)
                return new Response<bool>(HttpStatusCode.BadRequest, "Mentor not found");

            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
      #endregion
}