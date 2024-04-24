using System.Data.Common;
using System.Net;
using AutoMapper;
using Domain.DTOs.StudentDTO;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.StudentService;

public class StudentService : IStudentService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public StudentService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    #region GetStudentsAsync

    public async Task<Response<List<GetStudentDto>>> GetStudentsAsync()
    {
        try
        {
            var students = await _context.Students.ToListAsync();
            var mapped = _mapper.Map<List<GetStudentDto>>(students);
            return new Response<List<GetStudentDto>>(mapped);
        }
        catch (DbException dbEx)
        {
            return new Response<List<GetStudentDto>>(HttpStatusCode.InternalServerError, dbEx.Message);
        }
        catch (Exception ex)
        {
            return new Response<List<GetStudentDto>>(HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    #endregion

    #region GetStudentByIdAsync

    public async Task<Response<GetStudentDto>> GetStudentByIdAsync(int id)
    {
        try
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student == null)
                return new Response<GetStudentDto>(HttpStatusCode.BadRequest, "Student not found");
            var mapped = _mapper.Map<GetStudentDto>(student);
            return new Response<GetStudentDto>(mapped);
        }
        catch (Exception e)
        {
            return new Response<GetStudentDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    #endregion

    #region CreateStudentAsync

    public async Task<Response<string>> CreateStudentAsync(AddStudentDto student)
    {
        try
        {
            var existingStudent = await _context.Students.FirstOrDefaultAsync(x => x.Email == student.Email);
            if (existingStudent != null)
                return new Response<string>(HttpStatusCode.BadRequest, "Student already exists");
            var mapped = _mapper.Map<Student>(student);

            await _context.Students.AddAsync(mapped);
            await _context.SaveChangesAsync();

            return new Response<string>("Successfully created a new student");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    #endregion

    #region UpdateStudentAsync

    public async Task<Response<string>> UpdateStudentAsync(UpdateStudentDto student)
    {
        try
        {
            var mappedStudent = _mapper.Map<Student>(student);
            _context.Students.Update(mappedStudent);
            var update= await _context.SaveChangesAsync();
            if(update==0)  return new Response<string>(HttpStatusCode.BadRequest, "Student not found");
            return new Response<string>("Student updated successfully");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    #endregion

    public async Task<Response<bool>> DeleteStudentAsync(int id)
    {
        try
        {
            var student = await _context.Students.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (student == 0)
                return new Response<bool>(HttpStatusCode.BadRequest, "Student not found");

            return new Response<bool>(true);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}