using Domain.DTOs;
using Domain.DTOs.CourseDTO;
using Domain.Responses;

namespace Infrastructure.Services.CourseService;

public interface ICourseService
{
    Task<Response<List<GetCourseDto>>>GetCoursesAsync();
    Task<Response<GetCourseDto>> GetCourseByIdAsync(int id);
    Task<Response<string>> CreateCourseAsync(AddCourseDto course);
    Task<Response<string>> UpdateCourseAsync(UpdateCourseDto course);
    Task<Response<bool>> DeleteCourseAsync(int id);
}
