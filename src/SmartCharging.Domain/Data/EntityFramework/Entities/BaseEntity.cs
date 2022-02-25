using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCharging.Domain.Data.EntityFramework.Entities;

/// <summary>
/// BaseEntity
/// </summary>
[Serializable]
public abstract class BaseEntity : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
}

