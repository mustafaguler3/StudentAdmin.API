using AutoMapper;
using StudentAdmin.API.Data;
using StudentAdmin.API.DomainModels;

namespace StudentAdmin.API.Mappings.AutoMapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Gender, GenderDto>().ReverseMap();
        }
    }
}
