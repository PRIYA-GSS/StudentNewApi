

using AutoMapper;
using Models;
using StudentNewApi.DTOs;

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