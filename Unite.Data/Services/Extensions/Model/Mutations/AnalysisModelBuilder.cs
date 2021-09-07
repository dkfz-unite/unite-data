using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;
using Unite.Data.Entities.Mutations.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    internal static class AnalysisModelBuilder
    {
        internal static void BuildAnalysisModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Analysis>(entity =>
            {
                entity.ToTable("Analyses");

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
            });
        }
    }
}
