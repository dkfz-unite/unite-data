using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images.Features.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Images.Features.Enums;

internal class AnalysisTypeMapper : IEntityTypeConfiguration<EnumValue<AnalysisType>>
{
    public void Configure(EntityTypeBuilder<EnumValue<AnalysisType>> entity)
    {
        var data = new EnumValue<AnalysisType>[]
        {
            AnalysisType.RFE.ToEnumValue()
        };

        entity.BuildEnumEntity("AnalysisTypes", DomainDbSchemaNames.Images, data);
    }
}
