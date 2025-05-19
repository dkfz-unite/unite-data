using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Omics.Analysis;
using Unite.Data.Entities.Omics.Analysis.Dna.Cnv;

namespace Unite.Data.Context.Mappers.Omics.Analysis.Dna.Cnv;

/// <summary>
/// CNV occurrence mapper.
/// </summary>
internal class VariantEntryMapper : Base.SampleEntryMapper<VariantEntry, Sample, Variant>
{
    protected override string SchemaName => DomainDbSchemaNames.Omics;
    protected override string TableName => "cnv_entry";
    protected override string EntityColumnName => "variant_id";

    public override void Configure(EntityTypeBuilder<VariantEntry> entity)
    {
        base.Configure(entity);

        entity.HasOne(entry => entry.Entity)
              .WithMany(variant => variant.Entries)
              .HasForeignKey(entry => entry.EntityId);

        entity.HasOne(entry => entry.Sample)
              .WithMany(sample => sample.CnvEntries)
              .HasForeignKey(entry => entry.SampleId);
    }
}
