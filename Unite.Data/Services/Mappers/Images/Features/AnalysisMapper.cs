using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images.Features;
using Unite.Data.Entities.Images.Features.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Mappers.Images.Features
{
    internal class AnalysisMapper : IEntityTypeConfiguration<Analysis>
    {
        public void Configure(EntityTypeBuilder<Analysis> entity)
        {
            entity.ToTable("Analyses", DomainDbSchemaNames.Images);

            entity.HasKey(analysis => analysis.Id);

            entity.Property(analysis => analysis.Id)
                  .IsRequired()
                  .ValueGeneratedOnAdd();

            entity.Property(analysis => analysis.ReferenceId)
                  .HasMaxLength(255);

            entity.Property(analysis => analysis.TypeId)
                  .HasConversion<int>();


            entity.HasOne<EnumValue<AnalysisType>>()
                  .WithMany()
                  .HasForeignKey(analysis => analysis.TypeId);

            entity.HasOne(analysis => analysis.File)
                  .WithOne()
                  .HasForeignKey<Analysis>(analysis => analysis.FileId);


            entity.HasIndex(analysis => analysis.ReferenceId);
        }
    }
}
