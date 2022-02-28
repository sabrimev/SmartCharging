using AutoMapper;
using SmartCharging.Domain.Data.EntityFramework.Entities;
using SmartCharging.Service.Business.ChargeStations.DTOs;

namespace SmartCharging.Service.Business.ChargeStations.Mapping;

public class ChargeStationMapper : Profile
{
    public ChargeStationMapper()
    {
        CreateMap<ChargeStationDTO, ChargeStation>().ReverseMap();
        
        CreateMap<ChargeStationUpdateDTO, ChargeStation>()
            .ForMember(dest => dest.GroupId, opt => opt.Condition(src => (src.GroupId != Guid.Empty)));
    }
}
