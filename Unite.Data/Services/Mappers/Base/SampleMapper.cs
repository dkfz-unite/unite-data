using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Base;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Mappers.Base;

internal abstract class SampleMapper<TSample, TSampleType> : IEntityTypeConfiguration<TSample>
    where TSample : Sample<TSampleType>
    where TSampleType : struct, Enum
{
    protected abstract string TableName { get; }

    public virtual void Configure(EntityTypeBuilder<TSample> entity)
    {
        entity.ToTable(TableName);

        entity.HasKey(sample => sample.Id);

        entity.Property(sample => sample.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(sample => sample.ReferenceId)
              .IsRequired()
              .HasMaxLength(255)
              .ValueGeneratedNever();

        entity.Property(sample => sample.DonorId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(sample => sample.TypeId)
              .IsRequired()
              .HasConversion<int>();


        entity.HasOne<EnumValue<TSampleType>>()
              .WithMany()
              .HasForeignKey(sample => sample.TypeId);


        entity.HasIndex(sample => sample.ReferenceId);
    }
}
