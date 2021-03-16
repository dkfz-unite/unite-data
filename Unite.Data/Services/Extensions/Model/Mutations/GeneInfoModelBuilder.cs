using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    public static class GeneInfoModelBuilder
    {
        public static void BuildGeneInfoModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeneInfo>(entity =>
            {
                entity.ToTable("GeneInfo");

                entity.HasKey(geneInfo => geneInfo.GeneId);

                entity.Property(geneInfo => geneInfo.GeneId)
                      .IsRequired()
                      .ValueGeneratedNever();


                entity.HasOne<Gene>()
                      .WithOne(gene => gene.Info)
                      .HasForeignKey<GeneInfo>(geneInfo => geneInfo.GeneId)
                      .IsRequired();
            });
        }
    }
}
