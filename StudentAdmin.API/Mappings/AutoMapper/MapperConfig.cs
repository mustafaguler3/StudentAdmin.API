using AutoMapper;
using StudentAdmin.API.Data;
using StudentAdmin.API.DomainModels;
using StudentAdmin.API.Dtos;

namespace StudentAdmin.API.Mappings.AutoMapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<Student, CreateStudentDto>().ReverseMap();
            CreateMap<Student, UpdateStudentDto>()
                .ForMember(dest => dest.PhysicalAddress,opt=>opt.MapFrom(src => src.Address.PhysicalAddress))
                .ForMember(dest => dest.PostalAddress, opt => opt.MapFrom(src => src.Address.PostalAddress)); ;
        }
    }
}
