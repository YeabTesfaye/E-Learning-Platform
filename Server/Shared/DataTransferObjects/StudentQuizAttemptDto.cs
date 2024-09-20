namespace Shared.DataTransferObjects;


public class StudentQuizAttemptDto{
    public Guid Id { get; set; }
    public int AttemptDatetime { get; set; }
    public int ScoreAchieved { get; set; }
}