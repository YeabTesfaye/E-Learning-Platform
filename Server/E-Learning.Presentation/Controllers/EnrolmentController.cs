using Microsoft.AspNetCore.Mvc;
using Service.Intefaces;

namespace E_Learning.Presentation.Controllers;

[Route("/api/student/{studentId}/course/{courseId}/enrolment")]
[ApiController]
public class EnrolmentController : ControllerBase
{
   private readonly IServiceManager _service;  
   public EnrolmentController(IServiceManager service) => _service = service;
   
   [HttpGet]
   public IActionResult GetEnrolmentsForCourse(Guid studentId, Guid courseId){
    var enrolments = _service.EnrolmentService.GetEnrolments(studentId, courseId, trackChanges:false);
    return Ok(enrolments);
   }

   [HttpGet("{Id:guid}",Name ="GetEnrolmentById")]
   public IActionResult GetEnrolmentForCourse([FromRoute] Guid Id,[FromRoute] Guid studentId,[FromRoute] Guid courseId){
      var enrolment = _service.EnrolmentService.GetEnrolment(Id,studentId,courseId,trackChanges:false);
      return Ok(enrolment);
   }
   
} 