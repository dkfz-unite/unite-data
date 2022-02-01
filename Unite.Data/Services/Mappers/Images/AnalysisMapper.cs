using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images;
using Unite.Data.Entities.Images.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Mappers.Images
{
    internal class AnalysisMapper : IEntityTypeConfiguration<Analysis>
    {
        public void Configure(EntityTypeBuilder<Analysis> entity)
        {
            entity.ToTable("Analyses", DomainDbSchemaNames.Images);

            entity.HasKey(analysis => analysis.Id);

            entity.Property(analysis => analysis.Id)
                  .IsRequired()
                  .ValueGeneratedNever();

            entity.Property(analysis => analysis.ReferenceId)
                  .HasMaxLength(255);

            entity.Property(analysis => analysis.TypeId)
                  .HasConversion<int>();


            entity.HasOne<EnumValue<AnalysisType>>()
                  .WithMany()
                  .HasForeignKey(analysis => analysis.TypeId);


            entity.HasIndex(analysis => analysis.ReferenceId);
        }
    }
}
