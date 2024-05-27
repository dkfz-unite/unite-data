using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Analysis;
using Unite.Data.Entities.Genome.Analysis.Dna.Cnv;

namespace Unite.Data.Context.Mappers.Genome.Analysis.Dna.Cnv;

/// <summary>
/// CNV occurrence mapper.
/// </summary>
internal class VariantEntryMapper : Base.SampleEntryMapper<VariantEntry, Sample, Variant>
{
    protected override string SchemaName => DomainDbSchemaNames.Genome;
    protected override string TableName => "CnvEntries";
    protected override string EntityColumnName => "VariantId";

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
