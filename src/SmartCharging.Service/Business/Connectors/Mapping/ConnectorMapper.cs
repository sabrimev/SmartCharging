using AutoMapper;
using SmartCharging.Domain.Data.EntityFramework.Entities;
using SmartCharging.Service.Business.Connectors.DTOs;

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
