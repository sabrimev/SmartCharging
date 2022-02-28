using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCharging.Domain.Data.EntityFramework.Entities.Base;

namespace SmartCharging.Domain.Data.EntityFramework.Configurations.Base;

/// <summary>
/// BaseConf
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TKey"></typeparam>
internal abstract class BaseConf<T, TKey> : IEntityTypeConfiguration<T> where T : BaseEntity<TKey>
{
	public virtual void Configure(EntityTypeBuilder<T> builder)
	{
	}
}