namespace Entities.Exceptions;

public class QuestionNotFoundException(Guid id) : NotFoundException($"The Question with id : {id} doesn't exist in the database")
{
}