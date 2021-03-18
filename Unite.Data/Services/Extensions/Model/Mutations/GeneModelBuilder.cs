using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    public static class GeneModelBuilder
    {
        public static void BuildGeneModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gene>(entity =>
            {
                entity.ToTable("Genes");

                entity.HasKey(gene => gene.Id);

                entity.Property(gene => gene.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(gene => gene.ChromosomeId)
                      .HasConversion<int>();

            });
        }
    }
}