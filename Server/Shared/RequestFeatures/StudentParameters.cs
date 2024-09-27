namespace Shared.RequestFeatures;

public class StudentParameters : RequestParameters
{
    public StudentParameters() => OrderBy = "name";
    public uint MinAge { get; set; }
    public uint MaxAge { get; set; } = int.MaxValue;
    public bool ValidAgeRange => MaxAge > MinAge;
    public string? SearchTerm { get; set; }
    public string OrderBy { get; }
}