using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Unite.Data.Services.Models.Extensions
{
    internal static class EnumValueEntityTypeBuilderExtensions
    {
        internal static void BuildEnumEntity<T>(this EntityTypeBuilder<EnumValue<T>> entity, string tableName, EnumValue<T>[] data)
            where T : Enum
        {
            entity.ToTable(tableName);

            entity.BuildEnumEntity(data);
        }

        internal static void BuildEnumEntity<T>(this EntityTypeBuilder<EnumValue<T>> entity, string tableName, string tableSchema, EnumValue<T>[] data)
            where T : Enum
        {
            entity.ToTable(tableName, tableSchema);

            entity.BuildEnumEntity(data);
        }

        private static void BuildEnumEntity<T>(this EntityTypeBuilder<EnumValue<T>> entity, EnumValue<T>[] data)
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
}
