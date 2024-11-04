using System.Runtime.Serialization;

namespace Shared.DataTransferObjects;
[DataContract]
public class QuestionDto
{
    [DataMember]
    public Guid Id { get; set; }
    [DataMember]
    public string QuestionTitle { get; set; } 
}