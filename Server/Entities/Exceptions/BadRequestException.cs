namespace Entities.Exceptions;

public class BadRequestException  : Exception
{
    protected BadRequestException(string msg) : base(msg) { }

}