using System.Runtime.Serialization;

namespace Shared.DataTransferObjects;

[DataContract]
public class QuizDto
{
    [DataMember]
    public Guid Id { get; set; }
    [DataMember]
    public string Name { get; set; } = string.Empty;
    [DataMember]
    public int Number { get; set; }
    [DataMember]
    public int CourseOrder { get; set; }
    [DataMember]
    public bool IsPassRequired { get; set; }
}