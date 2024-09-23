using System.Runtime.Serialization;

namespace Shared.DataTransferObjects;

[DataContract]
public class StudentDto
{
    [DataMember]
    public Guid Id { get; set; }
    [DataMember]
    public string Email { get; set; } = string.Empty;
    [DataMember]
    public string FullName { get; set; } = string.Empty;
}



