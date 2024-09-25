using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace E_Learning.Presentation.Controllers;

[Route("/api/course/{courseId}/modules")]
[ApiController]
public class ModuleController : ControllerBase
{
    private readonly IServiceManager _service;
    public ModuleController(IServiceManager service) => _service = service;

    [HttpGet]
    public IActionResult GetModulesForCourse([FromRoute] Guid courseId)
    {
        var modules = _service.ModuleService.GetModules(courseId, trackChanges: false);
        return Ok(modules);
    }
    [HttpGet("{Id:guid}", Name = "GetModuleById")]
    public IActionResult GetModuleForCourse([FromRoute] Guid Id, [FromRoute] Guid courseId)
    {
        var module = _service.ModuleService.GetModule(Id, courseId, trackChanges: false);
        return Ok(module);
    }

    [HttpPost]
    public IActionResult CreateModule([FromRoute] Guid courseId, [FromBody] ModuleForCreation module)
    {
        if (module is null)
            return BadRequest("ModuleForCreation object is null");

        var moduleToReturn =
       _service.ModuleService.CreateModuleForCourse(courseId, module, trackChanges: false);

        return CreatedAtRoute("GetModuleById", new
        { courseId, id = moduleToReturn.Id }, moduleToReturn);
    }

    [HttpDelete("{moduleId:guid}")]
    public IActionResult DeleteModule([FromRoute] Guid moduleId, [FromRoute] Guid courseId)
    {
        _service.ModuleService.DeleteModule(moduleId, courseId, trackChanges: false);
        return NoContent();
    }
    [HttpPut("{moduleId:guid}")]
    public IActionResult UpdateModule([FromRoute] Guid moduleId, [FromRoute] Guid courseId, ModuleForUpdateDto moduleForUpdate){
        _service.ModuleService.UpdateModule(moduleId,courseId,moduleForUpdate,courseTrackChanges:false,moduleTrackChanges:true);
        return NoContent();
    }

}