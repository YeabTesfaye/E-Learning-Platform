using E_Learning.Presentation.ActionFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;
using Shared.DtoForCreation;

namespace E_Learning.Presentation.Controllers;

[Route("/api/student/{studentId}/course/{courseId}/enrolment")]
[ApiController]
public class EnrolmentController(IServiceManager service) : ControllerBase
{
   private readonly IServiceManager _service = service;

   [HttpGet]
   public async Task<IActionResult> GetEnrolmentsForCourse(Guid studentId, Guid courseId)
   {
      var enrolments = await _service.EnrolmentService.GetEnrolments(studentId, courseId, trackChanges: false);
      return Ok(enrolments);
   }

   [HttpGet("{Id:guid}", Name = "GetEnrolmentById")]
   public async Task<IActionResult> GetEnrolmentForCourse
   ([FromRoute] Guid Id, [FromRoute] Guid studentId, [FromRoute] Guid courseId)
   {
      var enrolment = await _service.EnrolmentService.GetEnrolment(Id, studentId, courseId, trackChanges: false);
      if (enrolment == null)
         return NotFound($"Enrolment with ID {Id} for student {studentId} in course {courseId} was not found.");
      return Ok(enrolment);
   }

   [HttpPost]
   [ServiceFilter(typeof(ValidationFilterAttribute))]
   [Authorize]
   public async Task<IActionResult> CreateEnrolment([FromRoute] Guid studentId, [FromRoute] Guid courseId,
    [FromBody] EnrolmentForCreation enrolment)
   {


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


}