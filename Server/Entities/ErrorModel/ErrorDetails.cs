using System.Text.Json;

namespace Entities.ErrorModel;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; }  = string.Empty;
    public override string ToString() => JsonSerializer.Serialize(this);
    
}