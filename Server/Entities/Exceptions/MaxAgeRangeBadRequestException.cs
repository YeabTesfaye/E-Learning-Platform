namespace Entities.Exceptions;

public class MaxAgeRangeBadRequestException : BadRequestException
{
    public MaxAgeRangeBadRequestException(string message): base(message)
    {
    }
}