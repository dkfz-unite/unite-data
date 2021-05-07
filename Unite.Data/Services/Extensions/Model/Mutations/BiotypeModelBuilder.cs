using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    public static class BiotypeModelBuilder
    {
        public static void BuildBiotypeModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Biotype>(entity =>
            {
                entity.ToTable("Biotypes");

                entity.HasKey(biotype => biotype.Id);

                entity.HasAlternateKey(biotype => biotype.Value);

                entity.Property(biotype => biotype.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(biotype => biotype.Value)
                      .IsRequired()
                      .HasMaxLength(100);
            });
        }
    }
}
