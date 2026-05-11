using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;

namespace Unite.Data.Context.Mappers.Base;

internal abstract class EnumEntityMapper<T> : IEntityTypeConfiguration<EnumEntity<T>> 
    where T : struct, Enum
{
    protected abstract string TableName { get; }
    protected abstract string SchemaName { get; }
    
    public void Configure(EntityTypeBuilder<EnumEntity<T>> builder)
    {
        var data = Enum.GetValues<T>()
            .Select(e => e.ToEnumValue())
            .ToArray();

        builder.BuildEnumEntity(TableName, SchemaName, data);
    }
}