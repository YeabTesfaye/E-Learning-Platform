namespace Entities.Exceptions;

public class AnswerNotFoundException  :NotFoundException
{

    public AnswerNotFoundException(Guid id)
: base($"The Answer with id : {id} doesn't exist in the database")
    {
    }
}