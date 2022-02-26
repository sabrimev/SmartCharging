using System.ComponentModel.DataAnnotations.Schema;
using SmartCharging.Domain.Data.EntityFramework.Entities.Base;

namespace SmartCharging.Domain.Data.EntityFramework.Entities;

public class Connector : BaseEntity<int>
{
	public decimal MaxCurrent { get; set; }
	
	public Guid ChargeStationId { get; set; }
  
	[ForeignKey(nameof(ChargeStationId))]
	public ChargeStation ChargeStation { get; set; }
}