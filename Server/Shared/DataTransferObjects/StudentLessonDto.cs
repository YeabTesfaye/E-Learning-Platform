using System.Runtime.Serialization;

namespace Shared.DataTransferObjects;

[DataContract]
public class StudentLessonDto
{
    [DataMember]
    public Guid Id { get; set; }
    [DataMember]
    public DateTime CompletedDatetime { get; set; }
}