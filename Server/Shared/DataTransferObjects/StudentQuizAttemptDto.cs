namespace Shared.DataTransferObjects;


public class StudentQuizAttemptDto{
    public Guid Id { get; set; }
    public DateTime AttemptDatetime { get; set; }
    public int ScoreAchieved { get; set; }
}