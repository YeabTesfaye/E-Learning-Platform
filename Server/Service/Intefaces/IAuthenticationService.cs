using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects;

namespace Service.Intefaces;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
}