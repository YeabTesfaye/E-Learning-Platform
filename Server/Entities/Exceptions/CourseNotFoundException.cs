namespace Entities.Exceptions;

public sealed class CourseNotFoundException(Guid id) : NotFoundException($"The Course with id : {id} doesn't exist in the database")
{
}

