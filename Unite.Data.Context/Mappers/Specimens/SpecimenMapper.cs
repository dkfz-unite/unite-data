using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens;

internal class SpecimenMapper : Base.SpecimenMapper<Specimen, SpecimenType>
{
    protected override string SchemaName => DomainDbSchemaNames.Specimens;
    protected override string TableName => "specimen";

    public override void Configure(EntityTypeBuilder<Specimen> entity)
    {
        base.Configure(entity);

        entity.HasOne(specimen => specimen.Parent)
              .WithMany(specimen => specimen.Children)
              .HasForeignKey(specimen => specimen.ParentId);

        entity.HasOne(specimen => specimen.Donor)
              .WithMany(donor => donor.Specimens)
              .HasForeignKey(specimen => specimen.DonorId);
    }
}
