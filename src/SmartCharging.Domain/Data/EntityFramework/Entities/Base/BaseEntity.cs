using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCharging.Domain.Data.EntityFramework.Entities.Base;

/// <summary>
/// BaseEntity
/// </summary>
[Serializable]
public abstract class BaseEntity<TKey>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public TKey Id { get; set; }
}

