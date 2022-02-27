namespace SmartCharging.Service.Common.DTOs;

public abstract class BaseDTO<TKey>
{
    public TKey Id { get; set; } 
    
    public bool IsSuccess { get; set; }
    public string ErrorMessage { get; set; }
    public string Exception { get; set; }
}