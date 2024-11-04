using E_Learning.Presentation.ActionFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;

namespace E_Learning.Presentation.Controllers;

[Route("/api/course/{courseId}/modules")]
[ApiController]
public class ModuleController(IServiceManager service) : ControllerBase
{
    private readonly IServiceManager _service = service;

    [HttpGet]
    public async Task<IActionResult> GetModulesForCourse([FromRoute] Guid courseId)
    {
        var modules = await _service.ModuleService.GetModules(courseId, trackChanges: true);
        return Ok(modules);
    }
    [HttpGet("{Id:guid}", Name = "GetModuleById")]
    public async Task<IActionResult> GetModuleForCourse([FromRoute] Guid Id, [FromRoute] Guid courseId)
    {
        var module = await _service.ModuleService.GetModule(Id, courseId, trackChanges: false);
        if(module is null) return NotFound();
        return Ok(module);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    [Authorize]
    public async Task<IActionResult> CreateModule([FromRoute] Guid courseId, [FromBody] ModuleForCreation module)
    {

        var createdModule = await _service.ModuleService.CreateModuleForCourse(courseId, module, trackChanges: true);
        return CreatedAtRoute("GetModuleById", new { courseId, id = createdModule.Id }, createdModule);
    }

    [HttpDelete("{moduleId:guid}")]
    [Authorize]
    public async Task<IActionResult> DeleteModule([FromRoute] Guid moduleId, [FromRoute] Guid courseId)
    {
        await _service.ModuleService.DeleteModule(moduleId, courseId, trackChanges: false);
        return NoContent();
    }
   

}