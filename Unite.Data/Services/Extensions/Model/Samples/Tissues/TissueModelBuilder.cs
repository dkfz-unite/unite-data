using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Samples.Tissues;
using Unite.Data.Entities.Samples.Tissues.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Samples.Tissues
{
    public static class TissueModelBuilder
    {
        public static void BuildTissueModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tissue>(entity =>
            {
                entity.ToTable("Tissues");

                entity.HasKey(tissue => tissue.Id);

                entity.Property(tissue => tissue.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(tissue => tissue.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(tissue => tissue.TypeId)
                      .HasConversion<int>();


                entity.HasOne<EnumValue<TissueType>>()
                      .WithMany()
                      .HasForeignKey(tissue => tissue.TypeId);
            });
        }
    }
}
