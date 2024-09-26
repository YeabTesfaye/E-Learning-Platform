using System.ComponentModel.DataAnnotations;

namespace Shared.ManipulationDto;

public class ModuleForManipulationDto
{
    [Required(ErrorMessage = "Module name is required.")]
    [StringLength(100, ErrorMessage = "Module name cannot be longer than 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Module number is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Module number must be greater than zero.")]
    public int Number { get; set; }
}
