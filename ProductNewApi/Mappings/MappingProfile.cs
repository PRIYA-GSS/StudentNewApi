

using AutoMapper;
using Student = DataAccess.Entities.Student;
using StudentDto = Models.DTOs.Student;

namespace StudentNewApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}