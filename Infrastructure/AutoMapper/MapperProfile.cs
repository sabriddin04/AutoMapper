using AutoMapper;
using Domain.DTOs;
using Domain.DTOs.CourseDTO;
using Domain.DTOs.GroupDTO;
using Domain.DTOs.MentorDTO;
using Domain.DTOs.StudentDTO;
using Domain.Entities;

namespace Infrastructure.AutoMapper;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<Student, AddStudentDto>().ReverseMap();
        CreateMap<Student, GetStudentDto>().ReverseMap();
        CreateMap<Student, UpdateStudentDto>().ReverseMap();
        CreateMap<Mentor, AddMentorDto>().ReverseMap();
        CreateMap<Mentor, GetMentorDto>().ReverseMap();
        CreateMap<Mentor, UpdateMentorDto>().ReverseMap();
        CreateMap<Course, AddCourseDto>().ReverseMap();
        CreateMap<Course, GetCourseDto>().ReverseMap();
        CreateMap<Course, UpdateCourseDto>().ReverseMap();
        
        CreateMap<Group, AddGroupDto>().ReverseMap();
        CreateMap<Group, GetGroupDto>().ReverseMap();
        CreateMap<Group, UpdateGroupDto>().ReverseMap();
        
        // //ForMembers
        // CreateMap< Student,GetStudentDto>()
        //     .ForMember(sDto => sDto.FulName, opt => opt.MapFrom(s => $"{s.FirstName} {s.LastName}"))
        //     .ForMember(sDto => sDto.EmailAddress, opt => opt.MapFrom(s =>s.Email));
        //
        // //Reverse map
        // CreateMap<BaseStudentDto,Student>().ReverseMap();
        //
        // // ignore
        // CreateMap<Student, AddStudentDto>()
        //     .ForMember(dest => dest.FirstName, opt => opt.Ignore());


    }   
}