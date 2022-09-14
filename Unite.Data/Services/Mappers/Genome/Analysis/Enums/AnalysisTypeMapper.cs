﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Analysis.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Genome.Analysis.Enums;

internal class AnalysisTypeMapper : IEntityTypeConfiguration<EnumValue<AnalysisType>>
{
    public void Configure(EntityTypeBuilder<EnumValue<AnalysisType>> entity)
    {
        var data = new EnumValue<AnalysisType>[]
        {
            AnalysisType.Other.ToEnumValue(name: "Other Analysis"),
            AnalysisType.WGS.ToEnumValue(name: "Whole Genome Sequencing"),
            AnalysisType.WES.ToEnumValue(name: "Whole Exome Sequencing"),
            AnalysisType.RNASeq.ToEnumValue(name: "RNA Sequencing"),
            AnalysisType.MS.ToEnumValue(name: "Mass Spectrometry"),
            AnalysisType.Microarray.ToEnumValue("Microarray Analysis")
        };

        entity.BuildEnumEntity("AnalysisTypes", DomainDbSchemaNames.Genome, data);
    }
}