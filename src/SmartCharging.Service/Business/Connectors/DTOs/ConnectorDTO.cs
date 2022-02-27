using SmartCharging.Service.Common.DTOs;

namespace SmartCharging.Service.Business.Connectors.DTOs;

public class ConnectorDTO : BaseDTO<int>
{
    public decimal MaxCurrent { get; set; }
	
    public Guid ChargeStationId { get; set; }
}