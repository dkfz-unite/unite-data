using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Mappers.Base;

internal abstract class SampleMapper<TSample, TSampleType> : IEntityTypeConfiguration<TSample>
    where TSample : Entities.Base.Sample<TSampleType>
    where TSampleType : struct, Enum
{
    public abstract string TableName { get; }
    public abstract string SchemaName { get; } 


    public virtual void Configure(EntityTypeBuilder<TSample> entity)
    {
        entity.ToTable(TableName, SchemaName);

        entity.HasKey(sample => sample.Id);

        entity.Property(sample => sample.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(sample => sample.ReferenceId)
              .IsRequired()
              .HasMaxLength(255);

        entity.Property(sample => sample.TypeId)
              .IsRequired()
              .HasConversion<int>();


        entity.HasOne<EnumValue<TSampleType>>()
              .WithMany()
              .HasForeignKey(sample => sample.TypeId);

      
        entity.HasIndex(sample => sample.ReferenceId);
        
        entity.HasIndex(sample => sample.TypeId);
    }
}
