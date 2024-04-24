using Domain.DTOs;
using Domain.DTOs.CourseDTO;
using Domain.Responses;
using Infrastructure.Services.CourseService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("[controller]")]
[ApiController]
public class CourseController(ICourseService courseService):ControllerBase
{

    [HttpGet("get-courses")]
    public async Task<Response<List<GetCourseDto>>> GetCoursesAsync()
    {
        return await courseService.GetCoursesAsync();
    }
    [HttpGet("{courseId:int}")]
    public async Task<Response<GetCourseDto>> GetCourseByIdAsync(int id)
    {
        return await courseService.GetCourseByIdAsync(id);
    }
    
    [HttpPost("create-course")]
    public async Task<Response<string>> AddCourseAsync(AddCourseDto addCourseDto )
    {
        return await courseService.CreateCourseAsync(addCourseDto);
    }
    
    [HttpPut("update-course")]
    public async Task<Response<string>> UpdateCourseAsync(UpdateCourseDto updateCourseDto)
    {
        return await courseService.UpdateCourseAsync(updateCourseDto);
    }
    
    [HttpDelete("{courseId:int}")]
    public async Task<Response<bool>> DeleteCourseAsync(int id)
    {
        return await courseService.DeleteCourseAsync(id);
    }
    
}
