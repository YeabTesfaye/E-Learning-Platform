namespace Entities.Exceptions;

public class QuizNotFoundException(Guid id) : NotFoundException($"The Quiz with id : {id} doesn't exist in the database")
{
}