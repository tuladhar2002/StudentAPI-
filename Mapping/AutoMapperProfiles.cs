using AutoMapper;
using StudentAPI_Main.Domain.DTO;
using StudentAPI_Main.Domain.Models;

namespace StudentAPI_Main.Mapping
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student,StudentDto>().ReverseMap();
            CreateMap<Student, CreateStudentDto>().ReverseMap();
            CreateMap<Class, ClassDto>().ReverseMap();
            CreateMap<Ranking, RankingDto>().ReverseMap();

        }
    }
}
