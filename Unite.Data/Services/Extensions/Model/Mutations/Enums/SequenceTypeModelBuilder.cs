﻿using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Mutations.Enums
{
    public static class SequenceTypeModelBuilder
    {
        public static void BuildSequenceTypeModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<SequenceType>[]
            {
                SequenceType.CodingDNA.ToEnumValue(name: "Coding DNA"),
                SequenceType.NonCodingDNA.ToEnumValue(name: "Non Coding DNA"),
                SequenceType.LinearGenomicDNA.ToEnumValue(name: "Linear Genomic DNA"),
                SequenceType.CircularGenomicDNA.ToEnumValue(name: "Curcular Genomic DNA"),
                SequenceType.MitochondrialDNA.ToEnumValue(name: "Mitochondrial DNA"),
                SequenceType.RNA.ToEnumValue(name: "RNA"),
                SequenceType.Protein.ToEnumValue(name: "Protein")
            };

            modelBuilder.BuildEnumValueModel("SequenceTypes", data);
        }
    }
}
