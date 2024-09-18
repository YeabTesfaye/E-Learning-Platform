namespace Shared.DataTransferObjects;

public record StudentCourseDto
(
    Guid StudentCourseId,
    DateTime EnrollmentDate,
    bool IsCompleted
);