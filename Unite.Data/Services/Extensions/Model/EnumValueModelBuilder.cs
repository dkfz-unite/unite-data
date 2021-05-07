using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model
{
    internal static class EnumValueModelBuilder
    {
        public static void BuildEnumValueModel<T>(this ModelBuilder modelBuilder, EnumValue<T>[] data)
            where T : Enum
        {

            modelBuilder.Entity<EnumValue<T>>(entity =>
            {
                entity.BuildEnumEntity(data);
            });
        }

        public static void BuildEnumValueModel<T>(this ModelBuilder modelBuilder, string tableName, EnumValue<T>[] data)
            where T : Enum
        {
            modelBuilder.Entity<EnumValue<T>>(entity =>
            {
                entity.ToTable(tableName);

                entity.BuildEnumEntity(data);
            });
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
