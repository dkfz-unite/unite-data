using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Specimens.Analysis.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Analysis.Enums;

internal class AnalysisTypeMapper : IEntityTypeConfiguration<EnumEntity<AnalysisType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<AnalysisType>> entity)
    {
        var data = new EnumEntity<AnalysisType>[]
        {
            AnalysisType.DSA.ToEnumValue(name: "Drugs Screening Analysis")
        };

        entity.BuildEnumEntity("AnalysisTypes", DomainDbSchemaNames.Specimens, data);
    }
}
