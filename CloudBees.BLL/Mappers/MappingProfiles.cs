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
        CreateMap<AlertsStats, AlertsStatsDTO>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.Year.ToString().Substring(2)+"/"+src.Date.Month+"/"+src.Date.Day+"-"+src.Date.Hour));
        CreateMap<UsersStats, UserStatsDTO>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.Year.ToString().Substring(2) + "/" + src.Date.Month + "/" + src.Date.Day + "-" + src.Date.Hour)); ;
    }
}