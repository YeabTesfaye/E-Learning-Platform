using System.Runtime.Serialization;

namespace Shared.DataTransferObjects;

[DataContract]
public class StudentDto
{
    [DataMember]
    public Guid Id { get; set; }
    [DataMember]
    public string Email { get; set; }
    [DataMember]
    public string FullName { get; set; }
    [DataMember]
    public string Sex { get; set; }
    [DataMember]
    public int Age { get; set; }
}



