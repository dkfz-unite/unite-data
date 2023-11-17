using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Variants.SV;
using Unite.Data.Services.Mappers.Base;

namespace Unite.Data.Services.Mappers.Genome.Variants.SV;

/// <summary>
/// SV entry mapper
/// </summary>
internal class VariantEntryMapper : AnalysisEntityEntryMapper<VariantEntry, Variant, long>
{
    public override string TableName => "SvEntries";
    public override string SchemaName => DomainDbSchemaNames.Genome;

    public override string EntityColumnName => "VariantId";
    public override string AnalysedSampleColumnName => "AnalysedSampleId";


    public override void Configure(EntityTypeBuilder<VariantEntry> entity)
    {
        base.Configure(entity);


        entity.HasOne(entry => entry.Entity)
              .WithMany(variant => variant.Entries)
              .HasForeignKey(entry => entry.EntityId);

        entity.HasOne(entry => entry.AnalysedSample)
              .WithMany(analysedSample => analysedSample.SvEntries)
              .HasForeignKey(entry => entry.AnalysedSampleId);
    }
}
