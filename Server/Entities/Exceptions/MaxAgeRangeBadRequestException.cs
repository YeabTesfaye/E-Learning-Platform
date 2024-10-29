namespace Entities.Exceptions;

public class MaxAgeRangeBadRequestException(string message) : BadRequestException(message)
{
}