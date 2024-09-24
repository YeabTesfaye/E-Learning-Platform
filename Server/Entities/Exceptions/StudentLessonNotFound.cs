namespace Entities.Exceptions;

public class StudentLessonNotFound(Guid id) : NotFoundException($"The StudentLessonNotFound with id : {id} doesn't exist in the database")
{
}