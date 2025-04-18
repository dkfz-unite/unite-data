﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Entities.Specimens.Lines;
using Unite.Data.Entities.Specimens.Lines.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Lines;

internal class LineMapper : IEntityTypeConfiguration<Line>
{
    public void Configure(EntityTypeBuilder<Line> entity)
    {
        entity.ToTable("line", DomainDbSchemaNames.Specimens);

        entity.HasKey(line => line.SpecimenId);

        entity.Property(line => line.SpecimenId)
              .IsRequired()
              .ValueGeneratedNever();


        entity.HasOne<EnumEntity<CellsSpecies>>()
              .WithMany()
              .HasForeignKey(line => line.CellsSpeciesId);

        entity.HasOne<EnumEntity<CellsType>>()
              .WithMany()
              .HasForeignKey(line => line.CellsTypeId);

        entity.HasOne<EnumEntity<CellsCultureType>>()
              .WithMany()
              .HasForeignKey(line => line.CellsCultureTypeId);


        entity.HasOne(line => line.Specimen)
              .WithOne(specimen => specimen.Line)
              .HasForeignKey<Line>(line => line.SpecimenId)
              .IsRequired();
    }
}
