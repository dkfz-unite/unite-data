using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Radiology.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Extensions.Model;

namespace Unite.Data.Services.Mappers.Radiology.Enums
{
    internal class AnalysisTypeMapper : IEntityTypeConfiguration<EnumValue<AnalysisType>>
    {
        public void Configure(EntityTypeBuilder<EnumValue<AnalysisType>> builder)
        {
            var data = new EnumValue<AnalysisType>[]
            {
                AnalysisType.RFE.ToEnumValue()
            };

            builder.BuildEnumEntity("AnalysisTypes", DomainDbSchemaNames.Radiology, data);
        }
    }
}
