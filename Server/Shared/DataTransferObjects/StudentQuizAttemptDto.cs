using System.Runtime.Serialization;

namespace Shared.DataTransferObjects;

[DataContract] 
public class StudentQuizAttemptDto{
    [DataMember]
    public Guid Id { get; set; }
    [DataMember]
    public DateTime AttemptDatetime { get; set; }
    [DataMember]
    public int ScoreAchieved { get; set; }
}