using Contracts;
using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;

namespace E_Learning.Presentation.Controllers;

[Route("api/certofocate")]
[ApiController]
public class CertificateController : ControllerBase
{
     private readonly ICertificateService _certificateService;
    private readonly ILoggerManager _logger;
    public CertificateController(ICertificateService certificateService, ILoggerManager logger)
    {
        _certificateService = certificateService;
        _logger = logger;
    }
    [HttpGet]
    public IActionResult GetAllCertificates()
    {
        var courses = _certificateService.GetAllCertificates(trackChanges:false);
        return Ok(courses);
    }
}