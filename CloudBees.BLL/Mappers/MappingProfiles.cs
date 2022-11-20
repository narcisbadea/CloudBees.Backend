using AutoMapper;
using CloudBees.BLL.DTOs;
using CloudBees.DAL.Entities;

namespace CloudBees.BLL.Mapper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<RegisterDTO, User>().ReverseMap();
    }
}