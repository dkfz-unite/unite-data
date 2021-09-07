using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    internal static class GeneInfoModelBuilder
    {
        internal static void BuildGeneInfoModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeneInfo>(entity =>
            {
                entity.ToTable("GeneInfo");

                entity.HasKey(geneInfo => geneInfo.GeneId);

                entity.Property(geneInfo => geneInfo.GeneId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(geneInfo => geneInfo.EnsemblId)
                      .HasMaxLength(255);


                entity.HasOne<Gene>()
                      .WithOne(gene => gene.Info)
                      .HasForeignKey<GeneInfo>(geneInfo => geneInfo.GeneId)
                      .IsRequired();


                entity.HasIndex(geneInfo => geneInfo.EnsemblId)
                      .IsUnique();
            });
        }
    }
}
