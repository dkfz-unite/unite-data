﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Specimens.Xenografts.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Xenografts.Enums;

internal class ImplantLocationMapper : IEntityTypeConfiguration<EnumEntity<ImplantLocation>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<ImplantLocation>> entity)
    {
        var data = new EnumEntity<ImplantLocation>[]
        {
            ImplantLocation.Other.ToEnumValue(),
            ImplantLocation.Striatal.ToEnumValue(),
            ImplantLocation.Cortical.ToEnumValue()
        };

        entity.BuildEnumEntity("implant_location", DomainDbSchemaNames.Specimens, data);
    }
}
