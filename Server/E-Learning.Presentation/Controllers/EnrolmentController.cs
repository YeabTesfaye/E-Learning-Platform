using E_Learning.Presentation.ActionFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;
using Shared.DtoForUpdate;

namespace E_Learning.Presentation.Controllers;

[Route("/api/student/{studentId}/course/{courseId}/enrolment")]
[ApiController]
public class EnrolmentController : ControllerBase
{
   private readonly IServiceManager _service;
   public EnrolmentController(IServiceManager service) => _service = service;

   [HttpGet]
   [Authorize]
   public async Task<IActionResult> GetEnrolmentsForCourse(Guid studentId, Guid courseId)
   {
      var enrolments = await _service.EnrolmentService.GetEnrolments(studentId, courseId, trackChanges: false);
      return Ok(enrolments);
   }

   [HttpGet("{Id:guid}", Name = "GetEnrolmentById")]
   [Authorize]
   public async Task<IActionResult> GetEnrolmentForCourse([FromRoute] Guid Id, [FromRoute] Guid studentId, [FromRoute] Guid courseId)
   {
      var enrolment = await _service.EnrolmentService.GetEnrolment(Id, studentId, courseId, trackChanges: false);
      return Ok(enrolment);
   }

   [HttpPost]
   [ServiceFilter(typeof(ValidationFilterAttribute))]
   [Authorize]
   public async Task<IActionResult> CreateEnrolment([FromRoute] Guid studentId, [FromRoute] Guid courseId,
    [FromBody] EnrolmentForCreation enrolment)
   {
      if (enrolment is null)
         return BadRequest("EnrolmentForCreation object is null");
      if (!ModelState.IsValid)
         return UnprocessableEntity(ModelState);

      var enrolmentToReturn = await _service.EnrolmentService.CreateEnrolment(studentId, courseId, enrolment, trackChanges: false);

      return CreatedAtRoute("GetEnrolmentById", new { Id = enrolmentToReturn.Id, studentId, courseId }, enrolmentToReturn);
   }

   [HttpDelete("{enrolmentId:guid}")]
   [Authorize]
   public async Task<IActionResult> DeleteEnrolment([FromRoute] Guid studentId, [FromRoute] Guid courseId, Guid enrolmentId)
   {
      await _service.EnrolmentService.DeleteEnrolment(enrolmentId, studentId, courseId, trackChanges: false);
      return NoContent();
   }
   [HttpPut("{enrolmentId:guid}")]
   [ServiceFilter(typeof(ValidationFilterAttribute))]
   [Authorize]
   public async Task<IActionResult> UpdateEnrolment([FromRoute] Guid studentId, [FromRoute] Guid courseId,
    Guid enrolmentId, EnrolmentForUpdateDto enrolmentForUpdate)
   {
      if (!ModelState.IsValid)
      {
         return UnprocessableEntity(ModelState);
      }
      await _service.EnrolmentService.UpdateEnrolment(enrolmentId, studentId, courseId, enrolmentForUpdate, enrolmentTrackChanges: true,
        studentTrackChanges: false, courseTrackChanges: false);
      return NoContent();
   }

}