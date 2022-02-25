using System;

namespace SmartCharging.Domain.Data.EntityFramework.Entities;

/// <summary>
/// IEntity
/// </summary>
public interface IEntity
{
	Guid Id { get; set; }
}
