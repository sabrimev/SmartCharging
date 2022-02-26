using System.ComponentModel.DataAnnotations.Schema;
using SmartCharging.Domain.Data.EntityFramework.Entities.Base;

namespace SmartCharging.Domain.Data.EntityFramework.Entities;

public class ChargeStation : BaseEntity<Guid>
{
    public string Name { get; set; }
    
    public ICollection<Connector> Connectors { get; set; }

    public Guid GroupId { get; set; }
  
    [ForeignKey(nameof(GroupId))]
    public Group Group { get; set; }
}