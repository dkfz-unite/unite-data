using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome;

namespace Unite.Data.Services.Mappers.Genome;

internal class GeneInfoMapper : IEntityTypeConfiguration<GeneInfo>
{
    public void Configure(EntityTypeBuilder<GeneInfo> entity)
    {
        entity.ToTable("GeneInfo", DomainDbSchemaNames.Genome);

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
    }
}
