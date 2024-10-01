using System.Reflection;
using System.Text;
using Entities;
using System.Linq.Dynamic.Core;

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
    public static IQueryable<Student> Sort(this IQueryable<Student> students, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return students.OrderBy(s => s.FirstName);

        var orderParams = orderByQueryString.Trim().Split(',');
        var propertyInfos = typeof(Student).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var orderQueryBuilder = new StringBuilder();

        foreach (var param in orderParams)
        {
            if (string.IsNullOrWhiteSpace(param))
                continue;

            var propertyFromQueryName = param.Split(" ")[0];
            var objectProperty = propertyInfos.FirstOrDefault(pi =>
                pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

            if (objectProperty == null)
                continue;

            var direction = param.EndsWith(" desc") ? "descending" : "ascending";
            orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
        }

        var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

        if (string.IsNullOrWhiteSpace(orderQuery))
            return students.OrderBy(e => e.FirstName);

        // Use dynamic OrderBy from System.Linq.Dynamic.Core
        return students.OrderBy(orderQuery);
    }

}