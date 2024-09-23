using System.Runtime.Serialization;

namespace Shared.DataTransferObjects;

[DataContract]
public class CourseDto
{
  [DataMember]
  public Guid Id { get; set; }
  [DataMember]
  public string Name { get; set; } = string.Empty;
  [DataMember]
  public string Description { get; set; } = string.Empty;
  [DataMember]
  public decimal Price { get; set; }
  [DataMember]
  public bool IsProgressLimited { get; set; }
}