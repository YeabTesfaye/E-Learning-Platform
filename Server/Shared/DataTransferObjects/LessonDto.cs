using System.Runtime.Serialization;

namespace Shared.DataTransferObjects;

[DataContract]
public class LessonDto
{
    [DataMember]
    public Guid Id { get; set; }

    [DataMember]
    public int CourseOrder { get; set; }

    [DataMember]
    public string? LessonDetails { get; set; }

    [DataMember]
    public string? Name { get; set; }

    [DataMember]
    public int Number { get; set; }

    [DataMember]
    public string? VideoUrl { get; set; }
}
