namespace Entities.Exceptions;

public class LessonNotFounException : NotFoundException
{
     public LessonNotFounException(Guid id)
 : base($"The Lesson with id : {id} doesn't exist in the database")
    {
    }
}