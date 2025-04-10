using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
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

        entity.BuildEnumEntity("analysis_type", DomainDbSchemaNames.Specimens, data);
    }
}
