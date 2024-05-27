using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Genome.Analysis.Dna.Ssm.Enums;

namespace Unite.Data.Context.Mappers.Genome.Analysis.Dna.Ssm.Enums;

internal class SsmTypeMapper : IEntityTypeConfiguration<EnumEntity<SsmType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<SsmType>> entity)
    {
        var data = new EnumEntity<SsmType>[]
        {
            SsmType.SNV.ToEnumValue(name: "Single Nucleotide Variant"),
            SsmType.INS.ToEnumValue(name: "Insertion"),
            SsmType.DEL.ToEnumValue(name: "Deletion"),
            SsmType.MNV.ToEnumValue(name: "Multiple Nucleotide Variant")
        };

        entity.BuildEnumEntity("SsmTypes", DomainDbSchemaNames.Genome, data);
    }
}
