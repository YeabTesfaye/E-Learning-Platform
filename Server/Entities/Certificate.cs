using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Certificate
{
    public Guid CertificateId { get; set; }
    public string? CertificateCode { get; set; }
    [ForeignKey(nameof(Student))]
    public Guid StudentId { get; set; }
    public Student? Student { get; set; }
    [ForeignKey(nameof(Course))]
    public Guid CourseId { get; set; }
    public Course? Course { get; set; }
    public DateTime IssuedDate { get; set; }
}