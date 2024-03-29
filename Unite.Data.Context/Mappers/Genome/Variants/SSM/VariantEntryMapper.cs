﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Analysis;
using Unite.Data.Entities.Genome.Variants.SSM;

namespace Unite.Data.Context.Mappers.Genome.Variants.SSM;

/// <summary>
/// SSM occurrence mapper.
/// </summary>
internal class VariantEntryMapper : Base.AnalysedSampleEntryMapper<VariantEntry, AnalysedSample, Variant, long>
{
    protected override string SchemaName => DomainDbSchemaNames.Genome;
    protected override string TableName => "SsmEntries";
    protected override string EntityColumnName => "VariantId";

    public override void Configure(EntityTypeBuilder<VariantEntry> entity)
    {
        base.Configure(entity);

        entity.HasOne(entry => entry.Entity)
              .WithMany(variant => variant.Entries)
              .HasForeignKey(entry => entry.EntityId);

        entity.HasOne(entry => entry.AnalysedSample)
              .WithMany(analysedSample => analysedSample.SsmEntries)
              .HasForeignKey(entry => entry.AnalysedSampleId);
    }
}
