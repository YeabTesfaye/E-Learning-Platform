namespace Shared.DataTransferObjects;

public record CourseDto(
    Guid CourseId,
    string Title,
    string Description,
    int Credits
);