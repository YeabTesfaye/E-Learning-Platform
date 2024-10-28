using Entities;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace Repository.Extensions;

public static class RepositoryCourseExtensions
{
    public static IQueryable<Course> FilterCourses(this IQueryable<Course> courses, decimal minPrice, decimal maxPrice)
    {
        return courses.Where(c => c.Price >= minPrice && c.Price <= maxPrice);
    }
    public static IQueryable<Course> Search(this IQueryable<Course> courses, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return courses;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        // Ensure null values in FirstName don't cause an issue
        return courses.Where(c => c.Name != null && c.Name.ToLower().Contains(lowerCaseTerm));
    }
    public static IQueryable<Course> Sort(this IQueryable<Course> courses, string orderByQueryString)
    {
        if (string.IsNullOrWhiteSpace(orderByQueryString))
            return courses.OrderBy(c => c.Name);

        var orderParams = orderByQueryString.Trim().Split(',');
        var propertyInfos = typeof(Course).GetProperties(BindingFlags.Public | BindingFlags.Instance);
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
            return courses.OrderBy(c => c.Name);

        // Use dynamic OrderBy from System.Linq.Dynamic.Core
        return courses.OrderBy(orderQuery);
    }
}