namespace Entities.Exceptions;

public class QuestionNotFoundException : NotFoundException
{
    public QuestionNotFoundException(Guid id)
: base($"The Question with id : {id} doesn't exist in the database")
    {
    }
}