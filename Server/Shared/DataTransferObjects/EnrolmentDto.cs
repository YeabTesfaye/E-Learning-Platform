namespace Shared.DataTransferObjects;

public class EnrolmentDto{
    public Guid Id { get; set; }
    public DateTime EnrolmentDatetime { get; set; }
    public DateTime CompletedDatetime { get; set; }
}