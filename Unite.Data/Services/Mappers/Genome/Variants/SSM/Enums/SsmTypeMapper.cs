using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Variants.SSM.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Genome.Variants.SSM.Enums;

internal class SsmTypeMapper : IEntityTypeConfiguration<EnumValue<SsmType>>
{
    public void Configure(EntityTypeBuilder<EnumValue<SsmType>> entity)
    {
        var data = new EnumValue<SsmType>[]
        {
            SsmType.SNV.ToEnumValue(name: "Single Nucleotide Variant"),
            SsmType.INS.ToEnumValue(name: "Insertion"),
            SsmType.DEL.ToEnumValue(name: "Deletion"),
            SsmType.MNV.ToEnumValue(name: "Multiple Nucleotide Variant")
        };

        entity.BuildEnumEntity("SsmTypes", DomainDbSchemaNames.Genome, data);
    }
}
