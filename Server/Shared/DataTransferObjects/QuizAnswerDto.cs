using System.Runtime.Serialization;

namespace Shared.DataTransferObjects;

[DataContract]
public class QuizAnswerDto
{
    [DataMember]
    public Guid Id { get; set; }
    [DataMember]
    public string AnswerText { get; set; }
    [DataMember]
    public bool IsCorrect { get; set; }
}