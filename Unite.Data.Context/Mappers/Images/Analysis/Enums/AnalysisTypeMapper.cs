using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Images.Analysis.Enums;

namespace Unite.Data.Context.Mappers.Images.Analysis.Enums;

internal class AnalysisTypeMapper : IEntityTypeConfiguration<EnumEntity<AnalysisType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<AnalysisType>> entity)
    {
        var data = new EnumEntity<AnalysisType>[]
        {
            AnalysisType.RFE.ToEnumValue(name: "Radiomics Features Extraction")
        };

        entity.BuildEnumEntity("analysis_type", DomainDbSchemaNames.Images, data);
    }
}
