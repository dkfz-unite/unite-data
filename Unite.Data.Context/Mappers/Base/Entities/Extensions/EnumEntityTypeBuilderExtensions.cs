using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Unite.Data.Context.Mappers.Base.Entities.Extensions;

internal static class EnumEntityTypeBuilderExtensions
{
    public static void BuildEnumEntity<T>(this EntityTypeBuilder<EnumEntity<T>> entity, string tableName, EnumEntity<T>[] data)
        where T : Enum
    {
        entity.ToTable(tableName);

        entity.BuildEnumEntity(data);
    }

    public static void BuildEnumEntity<T>(this EntityTypeBuilder<EnumEntity<T>> entity, string tableName, string tableSchema, EnumEntity<T>[] data)
        where T : Enum
    {
        entity.ToTable(tableName, tableSchema);

        entity.BuildEnumEntity(data);
    }

    public static void BuildEnumEntity<T>(this EntityTypeBuilder<EnumEntity<T>> entity, EnumEntity<T>[] data)
        where T : Enum
    {
        entity.HasKey(enumValue => enumValue.Id);

        entity.HasAlternateKey(enumValue => enumValue.Value);

        entity.Property(enumValue => enumValue.Id)
              .IsRequired()
              .HasConversion<int>()
              .ValueGeneratedNever();

        entity.Property(enumValue => enumValue.Value)
              .IsRequired()
              .HasMaxLength(100);

        entity.Property(enumValue => enumValue.Name)
              .HasMaxLength(100);

        entity.HasData(data);
    }
}
