using System.Runtime.Serialization;

namespace Shared.DataTransferObjects;
[DataContract]
public class QuizQuestionDto
{
    [DataMember]
    public Guid Id { get; set; }
    [DataMember]
    public string QuestionTitle { get; set; } = string.Empty;
}