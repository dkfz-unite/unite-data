using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Tissues;

namespace Unite.Data.Services.Extensions.Model.Specimens.Tissues
{
    public static class TissueSourceModelBuilder
    {
        public static void BuildTissueSourceModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TissueSource>(entity =>
            {
                entity.ToTable("TissueSources");

                entity.HasKey(tissueSource => tissueSource.Id);

                entity.HasAlternateKey(tissueSource => tissueSource.Value);

                entity.Property(tissueSource => tissueSource.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(tissueSource => tissueSource.Value)
                      .IsRequired()
                      .HasMaxLength(100);
            });
        }
    }
}
