﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Entities.Genome.Enums;
using Unite.Data.Entities.Genome.Variants;

namespace Unite.Data.Context.Mappers.Genome.Variants;

/// <summary>
/// Variant mapper
/// </summary>
/// <typeparam name="TVariant">Variant type</typeparam>
internal abstract class VariantMapper<TVariant> : Base.EntityMapper<TVariant, long>
    where TVariant : Variant
{
    protected override string SchemaName => DomainDbSchemaNames.Genome;
    
    public override void Configure(EntityTypeBuilder<TVariant> entity)
    {
        entity.ToTable(TableName, DomainDbSchemaNames.Genome);

        entity.Property(variant => variant.ChromosomeId)
              .IsRequired()
              .HasConversion<int>();

        entity.Property(variant => variant.Start)
              .IsRequired();

        entity.Property(variant => variant.End)
              .IsRequired();


        entity.HasOne<EnumEntity<Chromosome>>()
              .WithMany()
              .HasForeignKey(variant => variant.ChromosomeId);
    }
}
