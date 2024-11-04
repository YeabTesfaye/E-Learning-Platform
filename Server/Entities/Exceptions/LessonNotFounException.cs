namespace Entities.Exceptions;

public class LessonNotFounException(Guid id) : NotFoundException($"The Lesson with id : {id} doesn't exist in the database")
{
}