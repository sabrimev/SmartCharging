using AutoMapper;
using SmartCharging.Domain.Data.EntityFramework.Entities;
using SmartCharging.Service.Business.Groups.DTOs;

namespace SmartCharging.Service.Business.Groups.Mapping;

public class GroupMapper : Profile
{
    public GroupMapper()
    {
        CreateMap<GroupDTO, Group>().ReverseMap();
    }
}
