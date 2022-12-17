using AutoMapper;
using CloudBees.BLL.DTOs;
using CloudBees.DAL.Entities;
using CloudBees.DAL.Entitis;

namespace CloudBees.BLL.Mapper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RegisterDTO, User>().ReverseMap();
        CreateMap<AlertDTO, Alert>();
        CreateMap<AlertRequestDTO, Alert>().ReverseMap();
        CreateMap<Alert, AlertDTO>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Type))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));
        CreateMap<AlertType, AlertTypeDTO>();
        CreateMap<User, UserProfileDTO>();
        CreateMap<AlertsStats, AlertsStatsDTO>();
        CreateMap<UsersStats, UserStatsDTO>();
    }
}