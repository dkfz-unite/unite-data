using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Genome.Analysis.Dna.Sm.Enums;

namespace Unite.Data.Context.Mappers.Genome.Analysis.Dna.Sm.Enums;

internal class SmTypeMapper : IEntityTypeConfiguration<EnumEntity<SmType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<SmType>> entity)
    {
        var data = new EnumEntity<SmType>[]
        {
            SmType.SNV.ToEnumValue(name: "Single Nucleotide Variant"),
            SmType.INS.ToEnumValue(name: "Insertion"),
            SmType.DEL.ToEnumValue(name: "Deletion"),
            SmType.MNV.ToEnumValue(name: "Multiple Nucleotide Variant")
        };

        entity.BuildEnumEntity("sm_type", DomainDbSchemaNames.Genome, data);
    }
}
