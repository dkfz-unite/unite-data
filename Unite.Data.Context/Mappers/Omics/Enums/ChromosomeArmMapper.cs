using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Omics.Enums;

namespace Unite.Data.Context.Mappers.Omics.Enums;

internal class ChromosomeArmMapper: IEntityTypeConfiguration<EnumEntity<ChromosomeArm>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<ChromosomeArm>> builder)
    {
        var data = new EnumEntity<ChromosomeArm>[]
        {
            ChromosomeArm.P.ToEnumValue(name: "Short arm"),
            ChromosomeArm.Q.ToEnumValue(name: "Long arm")
        };

        builder.BuildEnumEntity("chromosome_arm", DomainDbSchemaNames.Omics, data);
    }
}