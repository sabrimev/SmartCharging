using AutoMapper;
using SmartCharging.Service.Business.Groups.DTOs;
using SmartCharging.Domain.Data.EntityFramework.Entities;

namespace SmartCharging.Service.Business.Groups.Mapping;

public class GroupMapper : Profile
{
    public GroupMapper()
    {
        CreateMap<GroupDTO, Group>().ReverseMap();
    }
}
