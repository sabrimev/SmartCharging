using SmartCharging.Service.Common.DTOs;

namespace SmartCharging.Service.Business.Groups.DTOs;

public class GroupDTO : BaseDTO<Guid>
{
    public string Name { get; set; }
	
    public decimal Capacity { get; set; }
}