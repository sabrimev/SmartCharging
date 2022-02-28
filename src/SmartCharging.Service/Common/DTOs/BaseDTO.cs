namespace SmartCharging.Service.Common.DTOs;

public abstract class BaseDTO<TKey>
{
    public TKey Id { get; set; }
}