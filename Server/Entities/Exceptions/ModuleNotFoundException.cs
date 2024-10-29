namespace Entities.Exceptions;

public class ModuleNotFoundException(Guid id) : NotFoundException($"The Module with id : {id} doesn't exist in the database")
{
}