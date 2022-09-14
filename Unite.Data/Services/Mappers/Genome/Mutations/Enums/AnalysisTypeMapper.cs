using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Mutations.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Genome.Mutations.Enums;

internal class AnalysisTypeMapper : IEntityTypeConfiguration<EnumValue<AnalysisType>>
{
    public void Configure(EntityTypeBuilder<EnumValue<AnalysisType>> entity)
    {
        var data = new EnumValue<AnalysisType>[]
        {
            AnalysisType.WGS.ToEnumValue(),
            AnalysisType.WES.ToEnumValue()
        };

        entity.BuildEnumEntity("AnalysisTypes", DomainDbSchemaNames.Genome, data);
    }
}
