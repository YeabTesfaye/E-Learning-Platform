namespace Shared.RequestFeatures;

public class StudentParameters : RequestParameters
{
    public uint MinAge { get; set; }
    public uint MaxAge { get; set; }= uint.MaxValue;

    public bool ValidAgeRange => MaxAge > MinAge;

    public string? SearchTerm { get; set; }
    public StudentParameters() => OrderBy = "FirstName";

}