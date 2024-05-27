using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Analysis.Drugs;

namespace Unite.Data.Context.Mappers.Specimens.Analysis.Drugs;

internal class DrugMapper : Base.EntityMapper<Drug>
{
    protected override string SchemaName => DomainDbSchemaNames.Specimens;
    protected override string TableName => "Drugs";

    public override void Configure(EntityTypeBuilder<Drug> entity)
    {
        base.Configure(entity);

        entity.HasAlternateKey(drug => drug.Name);

        entity.Property(drug => drug.Name)
              .IsRequired()
              .HasMaxLength(100);
    }
}
