namespace Entities.Exceptions;

public class QuizAttemptNotFoundException(Guid id) : NotFoundException($"The attempt with id : {id} doesn't exist in the database")
{
}