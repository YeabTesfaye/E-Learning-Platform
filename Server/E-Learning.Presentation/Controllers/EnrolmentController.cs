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
   public IActionResult GetEnrolmentsForCourse(Guid studentId, Guid courseId)
   {
      var enrolments = _service.EnrolmentService.GetEnrolments(studentId, courseId, trackChanges: false);
      return Ok(enrolments);
   }

   [HttpGet("{Id:guid}", Name = "GetEnrolmentById")]
   public IActionResult GetEnrolmentForCourse([FromRoute] Guid Id, [FromRoute] Guid studentId, [FromRoute] Guid courseId)
   {
      var enrolment = _service.EnrolmentService.GetEnrolment(Id, studentId, courseId, trackChanges: false);
      return Ok(enrolment);
   }

   [HttpPost]
   public IActionResult CreateEnrolment([FromRoute] Guid studentId, [FromRoute] Guid courseId,
    [FromBody] EnrolmentForCreation enrolment)
   {
      if (enrolment is null)
         return BadRequest("EnrolmentForCreation object is null");

      var enrolmentToReturn = _service.EnrolmentService.CreateEnrolment(studentId, courseId, enrolment, trackChanges: false);

      return CreatedAtRoute("GetEnrolmentById", new { Id = enrolmentToReturn.Id, studentId, courseId }, enrolmentToReturn);
   }

   [HttpDelete("{enrolmentId:guid}")]
   public IActionResult DeleteEnrolment([FromRoute] Guid studentId, [FromRoute] Guid courseId, Guid enrolmentId)
   {
      _service.EnrolmentService.DeleteEnrolment(enrolmentId, studentId, courseId, trackChanges: false);
      return NoContent();
   }
   [HttpPut("{enrolmentId:guid}")]
   public IActionResult UpdateEnrolment([FromRoute] Guid studentId, [FromRoute] Guid courseId,
    Guid enrolmentId, EnrolmentForUpdateDto enrolmentForUpdate)
   {
      _service.EnrolmentService.UpdateEnrolment(enrolmentId, studentId, courseId, enrolmentForUpdate, enrolmentTrackChanges: true,
      studentTrackChanges: false, courseTrackChanges: false);
      return NoContent();
   }

}