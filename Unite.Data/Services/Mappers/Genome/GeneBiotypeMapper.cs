﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome;

namespace Unite.Data.Services.Mappers.Genome;

internal class GeneBiotypeMapper : IEntityTypeConfiguration<GeneBiotype>
{
    public void Configure(EntityTypeBuilder<GeneBiotype> entity)
    {
        entity.ToTable("GeneBiotypes", DomainDbSchemaNames.Genome);

        entity.HasKey(biotype => biotype.Id);

        entity.HasAlternateKey(biotype => biotype.Value);

        entity.Property(biotype => biotype.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(biotype => biotype.Value)
              .IsRequired()
              .HasMaxLength(100);
    }
}
