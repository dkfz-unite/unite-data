using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Tissues.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Specimens.Tissues.Enums
{
    internal class TissueTypeMapper : IEntityTypeConfiguration<EnumValue<TissueType>>
    {
        public void Configure(EntityTypeBuilder<EnumValue<TissueType>> entity)
        {
            var data = new EnumValue<TissueType>[]
            {
                TissueType.Control.ToEnumValue(),
                TissueType.Tumor.ToEnumValue()
            };

            entity.BuildEnumEntity("TissueTypes", DomainDbSchemaNames.Specimens, data);
        }
    }
}
