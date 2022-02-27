using SmartCharging.Service.Business.Connectors.DTOs;
using SmartCharging.Service.Common.DTOs;

namespace SmartCharging.Service.Business.ChargeStations.DTOs;

public class ChargeStationDTO : BaseDTO<Guid>
{
    public string Name { get; set; }
    
    public Guid GroupId { get; set; }

    public ICollection<ConnectorDTO> Connectors { get; set; }
}