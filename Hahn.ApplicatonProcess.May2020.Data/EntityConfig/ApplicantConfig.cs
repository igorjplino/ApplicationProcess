using Hahn.ApplicatonProcess.May2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hahn.ApplicatonProcess.May2020.Data.EntityConfig
{
    public class ApplicantConfig : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.HasKey(o => o.ID);

            builder.Property(o => o.Name)
                .IsRequired();
        }
    }
}
