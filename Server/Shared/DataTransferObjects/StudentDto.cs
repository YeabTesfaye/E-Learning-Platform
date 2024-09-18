namespace Shared.DataTransferObjects;

public record StudentDto(
        Guid StudentId, 
        string FullName, 
        string Email);