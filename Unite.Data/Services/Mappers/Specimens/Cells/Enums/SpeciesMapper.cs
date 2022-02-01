using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Cells.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Specimens.Cells.Enums
{
    internal class SpeciesMapper : IEntityTypeConfiguration<EnumValue<Species>>
    {
        public void Configure(EntityTypeBuilder<EnumValue<Species>> entity)
        {
            var data = new EnumValue<Species>[]
            {
                Species.Human.ToEnumValue(),
                Species.Mouse.ToEnumValue()
            };

            entity.BuildEnumEntity("Species", DomainDbSchemaNames.Specimens, data);
        }
    }
}
