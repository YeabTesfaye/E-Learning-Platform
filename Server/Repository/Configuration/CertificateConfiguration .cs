using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
{
    public void Configure(EntityTypeBuilder<Certificate> builder)
    {
        builder.HasData(
            new Certificate
            {
                CertificateId = new Guid("d76b8c60-2f4d-4b77-8f6d-ed2a5ab7c345"),
                CertificateCode = "CERT12345",
                StudentId = new Guid("e8e8cfcf-349d-4d7e-9f30-c0f0badd55ab"),
                CourseId = new Guid("a56d8b60-2f4d-4b77-8f6d-bd2a5ab7c345"),
                IssuedDate = new DateTime(2024, 6, 1)
            },
            new Certificate
            {
                CertificateId = new Guid("e86b8c60-2f4d-4b77-8f6d-ed2a5ab7c345"),
                CertificateCode = "CERT67890",
                StudentId = new Guid("d9d8cfcf-459d-4d7e-8f21-c0f0badd77cb"),
                CourseId = new Guid("b65d8b60-2f4d-4b77-8f6d-cd2a5ab7c345"),
                IssuedDate = new DateTime(2024, 6, 10)
            }
        );
    }
}
