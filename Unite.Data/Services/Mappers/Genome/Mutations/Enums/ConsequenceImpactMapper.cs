using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Mutations.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Genome.Mutations.Enums
{
    internal class ConsequenceImpactMapper : IEntityTypeConfiguration<EnumValue<ConsequenceImpact>>
    {
        public void Configure(EntityTypeBuilder<EnumValue<ConsequenceImpact>> entity)
        {
            var data = new EnumValue<ConsequenceImpact>[]
            {
                ConsequenceImpact.High.ToEnumValue(),
                ConsequenceImpact.Moderate.ToEnumValue(),
                ConsequenceImpact.Low.ToEnumValue(),
                ConsequenceImpact.Unknown.ToEnumValue(),
            };

            entity.BuildEnumEntity("ConsequenceImpacts", DomainDbSchemaNames.Genome, data);
        }
    }
}
