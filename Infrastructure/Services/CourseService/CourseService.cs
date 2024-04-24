using System.Data.Common;
using System.Net;
using AutoMapper;
using Domain.DTOs;
using Domain.DTOs.CourseDTO;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Services.CourseService;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.StudentService;

public class CourseService : ICourseService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CourseService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    #region GetMentorsAsync

    public async Task<Response<List<GetCourseDto>>> GetCoursesAsync()
    {
        try
        {
            var courses = await _context.Courses.ToListAsync();
            var mapped = _mapper.Map<List<GetCourseDto>>(courses);
            return new Response<List<GetCourseDto>>(mapped);
        }
        catch (DbException dbEx)
        {
            return new Response<List<GetCourseDto>>(HttpStatusCode.InternalServerError, dbEx.Message);
        }
        catch (Exception ex)
        {
            return new Response<List<GetCourseDto>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    #endregion

    #region GetMentorByIdAsync

    public async Task<Response<GetCourseDto>> GetCourseByIdAsync(int id)
    {
        try
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (course == null)
                return new Response<GetCourseDto>(HttpStatusCode.BadRequest, "Course not found");
            var mapped = _mapper.Map<GetCourseDto>(course);

            return new Response<GetCourseDto>(mapped);
        }
        catch (Exception e)
        {
            return new Response<GetCourseDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    #endregion

    #region CreateMentorAsync

    public async Task<Response<string>> CreateCourseAsync(AddCourseDto courseDto)
    {
        try
        {
            var existing = await _context.Courses.FirstOrDefaultAsync(x => x.CourseName == courseDto.CourseName);
            if (existing != null)
                return new Response<string>(HttpStatusCode.BadRequest, "Course already exists");
            var mapped = _mapper.Map<Mentor>(courseDto);

            await _context.Mentors.AddAsync(mapped);
            await _context.SaveChangesAsync();

            return new Response<string>("Successfully created a new course");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    #endregion

    #region UpdateMentorAsync

    public async Task<Response<string>> UpdateCourseAsync(UpdateCourseDto updateCourseDto)
    {
        try
        {
            var mapped = _mapper.Map<Course>(updateCourseDto);
            _context.Courses.Update(mapped);
            var update= await _context.SaveChangesAsync();
            if(update==0)  return new Response<string>(HttpStatusCode.BadRequest, "Course not found");
            return new Response<string>("Course updated successfully");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    #endregion

    #region DeleteMentorAsync
    public async Task<Response<bool>> DeleteCourseAsync(int id)
    {
        try
        {
            var mentor = await _context.Courses.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (mentor == 0)
                return new Response<bool>(HttpStatusCode.BadRequest, "Course not found");

            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
      #endregion
}
