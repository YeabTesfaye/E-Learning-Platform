using Entities;

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
}