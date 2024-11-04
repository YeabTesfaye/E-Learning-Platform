namespace Entities.Exceptions;

public class StudentNotFoundException(Guid studentId) : NotFoundException($"The Student with id : {studentId} doesn't exist in the database")
{
}