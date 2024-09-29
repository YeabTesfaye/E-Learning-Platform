namespace Shared.RequestFeatures;

public class StudentParameters : RequestParameters
{
    public uint MinAge { get; set; } 
    public uint MaxAge { get; set; }

    public bool ValidAgeRange => MaxAge >= MinAge;

    public string? SearchTerm { get; set; }
}