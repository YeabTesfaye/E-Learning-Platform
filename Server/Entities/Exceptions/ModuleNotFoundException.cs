namespace Entities.Exceptions;

public class ModuleNotFoundException : NotFoundException
{
    public ModuleNotFoundException(Guid id)
 : base($"The Module with id : {id} doesn't exist in the database")
    {
    }
}