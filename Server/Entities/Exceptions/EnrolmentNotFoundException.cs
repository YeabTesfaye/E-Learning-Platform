namespace Entities.Exceptions;

public class EnrolmentNotFoundException(Guid id) : NotFoundException($"The Course with id : {id} doesn't exist in the database")
{
}