namespace Entities.Exceptions;

public class EnrolmentNotFoundException : NotFoundException
{
    public EnrolmentNotFoundException(Guid id)
: base($"The Course with id : {id} doesn't exist in the database")
    {
    }
}