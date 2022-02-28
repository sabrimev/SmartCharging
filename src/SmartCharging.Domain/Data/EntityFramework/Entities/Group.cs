using SmartCharging.Domain.Data.EntityFramework.Entities.Base;

namespace SmartCharging.Domain.Data.EntityFramework.Entities;

public class Group : BaseEntity<Guid>
{
	public string Name { get; set; }
	
	public decimal Capacity { get; set; }
	
	public List<ChargeStation> ChargeStations { get; set; }
}


