using Entities;

namespace Repository.Extensions;

public static class RepositoryStudentExtensions
{
    public static IQueryable<Student> FilterStudents(this IQueryable<Student> students, uint minAge, uint maxAge)
    {
        return students.Where(s => s.Age >= minAge && s.Age <= maxAge);
    }
    public static IQueryable<Student> Search(this IQueryable<Student> students, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return students;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        // Ensure null values in FirstName don't cause an issue
        return students.Where(s => s.FirstName != null && s.FirstName.ToLower().Contains(lowerCaseTerm));
    }
}