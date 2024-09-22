namespace Entities.Exceptions;

public class QuizAttemptNotFoundException : NotFoundException
{
    public QuizAttemptNotFoundException(Guid id)
: base($"The attempt with id : {id} doesn't exist in the database")
    {
    }
}