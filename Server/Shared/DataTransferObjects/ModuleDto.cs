using System.Runtime.Serialization;

namespace Shared.DataTransferObjects;

[DataContract] 
public class ModuleDto
{
    [DataMember]
    public Guid Id { get; set; }
    [DataMember]
    public string Name { get; set; } = string.Empty;
    [DataMember]
    public int Number { get; set; }
}