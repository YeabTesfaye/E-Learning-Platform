namespace Entities.Exceptions;

public class QuizNotFoundException : NotFoundException
{
     public QuizNotFoundException(Guid id)
 : base($"The Quiz with id : {id} doesn't exist in the database")
    {
    }
}