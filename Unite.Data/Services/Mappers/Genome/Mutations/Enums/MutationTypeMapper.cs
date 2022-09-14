using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Mutations.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Genome.Mutations.Enums;

internal class MutationTypeMapper : IEntityTypeConfiguration<EnumValue<MutationType>>
{
    public void Configure(EntityTypeBuilder<EnumValue<MutationType>> entity)
    {
        var data = new EnumValue<MutationType>[]
        {
            MutationType.SNV.ToEnumValue(name: "Single Nucleotide Variant"),
            MutationType.INS.ToEnumValue(name: "Insertion"),
            MutationType.DEL.ToEnumValue(name: "Deletion"),
            MutationType.MNV.ToEnumValue(name: "Multiple Nucleotide Variant")
        };

        entity.BuildEnumEntity("MutationTypes", DomainDbSchemaNames.Genome, data);
    }
}
