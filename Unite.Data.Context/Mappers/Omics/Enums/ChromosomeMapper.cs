﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Omics.Enums;

namespace Unite.Data.Context.Mappers.Omics.Enums;

internal class ChromosomeMapper : IEntityTypeConfiguration<EnumEntity<Chromosome>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<Chromosome>> entity)
    {
        var data = new EnumEntity<Chromosome>[]
        {
            Chromosome.Chr1.ToEnumValue(name: "Chromosome 1"),
            Chromosome.Chr2.ToEnumValue(name: "Chromosome 2"),
            Chromosome.Chr3.ToEnumValue(name: "Chromosome 3"),
            Chromosome.Chr4.ToEnumValue(name: "Chromosome 4"),
            Chromosome.Chr5.ToEnumValue(name: "Chromosome 5"),
            Chromosome.Chr6.ToEnumValue(name: "Chromosome 6"),
            Chromosome.Chr7.ToEnumValue(name: "Chromosome 7"),
            Chromosome.Chr8.ToEnumValue(name: "Chromosome 8"),
            Chromosome.Chr9.ToEnumValue(name: "Chromosome 9"),
            Chromosome.Chr10.ToEnumValue(name: "Chromosome 10"),
            Chromosome.Chr11.ToEnumValue(name: "Chromosome 11"),
            Chromosome.Chr12.ToEnumValue(name: "Chromosome 12"),
            Chromosome.Chr13.ToEnumValue(name: "Chromosome 13"),
            Chromosome.Chr14.ToEnumValue(name: "Chromosome 14"),
            Chromosome.Chr15.ToEnumValue(name: "Chromosome 15"),
            Chromosome.Chr16.ToEnumValue(name: "Chromosome 16"),
            Chromosome.Chr17.ToEnumValue(name: "Chromosome 17"),
            Chromosome.Chr18.ToEnumValue(name: "Chromosome 18"),
            Chromosome.Chr19.ToEnumValue(name: "Chromosome 19"),
            Chromosome.Chr20.ToEnumValue(name: "Chromosome 20"),
            Chromosome.Chr21.ToEnumValue(name: "Chromosome 21"),
            Chromosome.Chr22.ToEnumValue(name: "Chromosome 22"),
            Chromosome.ChrX.ToEnumValue(name: "Chromosome X"),
            Chromosome.ChrY.ToEnumValue(name: "Chromosome Y"),
            Chromosome.ChrMT.ToEnumValue(name: "Chromosome MT"),
        };

        entity.BuildEnumEntity("chromosome", DomainDbSchemaNames.Omics, data);
    }
}
