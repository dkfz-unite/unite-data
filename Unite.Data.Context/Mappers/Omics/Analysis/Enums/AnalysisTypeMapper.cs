using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Omics.Analysis.Enums;

namespace Unite.Data.Context.Mappers.Omics.Analysis.Enums;

internal class AnalysisTypeMapper : IEntityTypeConfiguration<EnumEntity<AnalysisType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<AnalysisType>> entity)
    {
        var data = Enum.GetValues<AnalysisType>()
            .Select(e => e.ToEnumValue())
            .ToArray();

        entity.BuildEnumEntity("analysis_type", DomainDbSchemaNames.Omics, data);
    }
}
