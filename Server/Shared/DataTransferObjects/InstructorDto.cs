namespace Shared.DataTransferObjects;

public record InstructorDto(
    Guid InstructorId,
    Guid FullName,
    Guid Email
);