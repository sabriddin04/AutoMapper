using Domain.DTOs.StudentDTO;
using Domain.Responses;
using Infrastructure.Services.StudentService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("[controller]")]
[ApiController]
public class StudentController:ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet("get-students")]
    public async Task<Response<List<GetStudentDto>>> GetStudentsAsync()
    {
        return await _studentService.GetStudentsAsync();
    }
    [HttpGet("{studentId:int}")]
    public async Task<Response<GetStudentDto>> GetStudentByIdAsync(int studentId)
    {
        return await _studentService.GetStudentByIdAsync(studentId);
    }
    
    [HttpPost("create-student")]
    public async Task<Response<string>> AddStudentAsync(AddStudentDto studentDto)
    {
        return await _studentService.CreateStudentAsync(studentDto);
    }
    
    [HttpPut("update-student")]
    public async Task<Response<string>> UpdateStudentAsync(UpdateStudentDto studentDto)
    {
        return await _studentService.UpdateStudentAsync(studentDto);
    }
    
    [HttpDelete("{studentId:int}")]
    public async Task<Response<bool>> DeleteStudentAsync(int studentId)
    {
        return await _studentService.DeleteStudentAsync(studentId);
    }
    
   
    
}