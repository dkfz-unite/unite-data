using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Data.Services.Mappers.Base;

namespace Unite.Data.Services.Mappers.Specimens;

internal class SpecimenMapper : SampleMapper<Specimen, SpecimenType>
{
    public override string TableName => "Specimens";
    public override string SchemaName => DomainDbSchemaNames.Specimens;

    public override void Configure(EntityTypeBuilder<Specimen> entity)
    {
        base.Configure(entity);

        entity.Property(specimen => specimen.DonorId)
              .IsRequired()
              .ValueGeneratedNever();


        entity.HasOne(specimen => specimen.Parent)
              .WithMany(specimen => specimen.Children)
              .HasForeignKey(specimen => specimen.ParentId);

        entity.HasOne(specimen => specimen.Donor)
              .WithMany(donor => donor.Specimens)
              .HasForeignKey(specimen => specimen.DonorId);
    }
}
