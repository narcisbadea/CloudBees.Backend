using AutoMapper;
using CloudBees.BLL.DTOs;
using CloudBees.DAL.Entities;

namespace CloudBees.BLL.Mapper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RegisterDTO, User>().ReverseMap();
        CreateMap<AlertDTO, Alert>();
        CreateMap<AlertRequestDTO, Alert>().ReverseMap();
        CreateMap<Alert, AlertDTO>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Type));
        CreateMap<AlertType, AlertTypeDTO>()
            .ForMember(dest => dest.label, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.value, opt => opt.MapFrom(src => src.Type))
            .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id));
    }
}