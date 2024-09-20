namespace Entities.Exceptions;

public sealed class CourseNotFoundException : NotFoundException
{
    public CourseNotFoundException(Guid id)
 : base($"The Course with id : {id} doesn't exist in the database")
    {
    }
}

