using E_Learning.Presentation.ActionFilter;
using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DataTransferObjects;

namespace E_Learning.Presentation.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthenticationController(IServiceManager service) : ControllerBase
{
  private readonly IServiceManager _service = service;

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
  [HttpPost("login")]
  [ServiceFilter(typeof(ValidationFilterAttribute))]
  public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
  {
    if (!await _service.AuthenticationService.ValidateUser(user))
      return Unauthorized();
    var tokenDto = await _service.AuthenticationService.CreateToken(
      populateExp: true
    );
    return Ok(tokenDto);
  }

}
