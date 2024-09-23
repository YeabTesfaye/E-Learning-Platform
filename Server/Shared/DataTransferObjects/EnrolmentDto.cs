using System.Runtime.Serialization;

namespace Shared.DataTransferObjects;

[DataContract]
public class EnrolmentDto
{
    [DataMember]
    public Guid Id { get; set; }
    [DataMember]
    public DateTime EnrolmentDatetime { get; set; }
    [DataMember]
    public DateTime CompletedDatetime { get; set; }
}