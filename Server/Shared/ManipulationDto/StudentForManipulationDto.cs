using System.ComponentModel.DataAnnotations;

namespace Shared.ManipulationDto;

public class StudentForManipulationDto
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Sex is required.")]
    [RegularExpression("^(Male|Female)$", ErrorMessage = "Sex must be either 'Male' or 'Female'.")]
    public string Sex { get; set; } = string.Empty;

    [Range(8, int.MaxValue, ErrorMessage = "Age must be greater than 7.")]
    public int Age { get; set; }
}
