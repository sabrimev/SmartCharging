using System.Text.Json;

namespace SmartCharging.Service.Common.ErrorHandling;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string ExceptionDetail { get; set; }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}