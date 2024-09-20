namespace Entities.Exceptions;

public class StudentNotFoundException : NotFoundException
{
    public StudentNotFoundException(Guid studentId) 
    : base($"The Student with id : {studentId} doesn't exist in the database")
    {
    }
}