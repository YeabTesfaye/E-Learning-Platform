namespace Entities.Exceptions;

public class AnswerNotFoundException(Guid id) : NotFoundException($"The Answer with id : {id} doesn't exist in the database")
{
}