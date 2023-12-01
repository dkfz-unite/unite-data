using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Images.Analysis.Enums;

namespace Unite.Data.Context.Mappers.Images.Analysis.Enums;

internal class AnalysisTypeMapper : IEntityTypeConfiguration<EnumEntity<AnalysisType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<AnalysisType>> entity)
    {
        var data = new EnumEntity<AnalysisType>[]
        {
            AnalysisType.RFE.ToEnumValue()
        };

        entity.BuildEnumEntity("AnalysisTypes", DomainDbSchemaNames.Images, data);
    }
}
