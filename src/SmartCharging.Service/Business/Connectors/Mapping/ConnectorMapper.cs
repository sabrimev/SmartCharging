using AutoMapper;
using SmartCharging.Service.Business.Connectors.DTOs;
using SmartCharging.Domain.Data.EntityFramework.Entities;

namespace SmartCharging.Service.Business.Connectors.Mapping;

public class ConnectorMapper : Profile
{
    public ConnectorMapper()
    {
        CreateMap<ConnectorDTO, Connector>()
            .ForMember(dest => dest.ChargeStationId, opt => opt.Condition(src => (src.ChargeStationId != Guid.Empty)));

        CreateMap<Connector, ConnectorDTO>();
    }
}
