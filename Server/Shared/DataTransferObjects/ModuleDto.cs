namespace Shared.DataTransferObjects;

public record ModuleDto(
    Guid ModuleId,
    string Title,
    string Content
);