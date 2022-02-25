using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartCharging.Domain.Data.EntityFramework.Entities;

/// <summary>
/// BaseConf
/// </summary>
/// <typeparam name="T"></typeparam>
internal abstract class BaseConf<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
	public virtual void Configure(EntityTypeBuilder<T> builder)
	{
	}
}