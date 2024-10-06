using E_Learning.Presentation.ActionFilter;
using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DataTransferObjects;

namespace E_Learning.Presentation.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{
  private readonly IServiceManager _service;
  public AuthenticationController(IServiceManager service) => _service = service;

  [HttpPost]
  [ServiceFilter(typeof(ValidationFilterAttribute))]
  public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
  {
    var result = await _service.AuthenticationService.RegisterUser(userForRegistration);
    if (!result.Succeeded)
    {
      foreach (var error in result.Errors)
      {
        ModelState.TryAddModelError(error.Code, error.Description);

      }
      return BadRequest(ModelState);
    }
    return StatusCode(201);
  }
  
}