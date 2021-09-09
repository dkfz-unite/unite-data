using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    internal static class GeneBiotypeModelBuilder
    {
        internal static void BuildGeneBiotypeModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeneBiotype>(entity =>
            {
                entity.ToTable("GeneBiotypes");

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
