using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome;

namespace Unite.Data.Services.Mappers.Genome
{
    internal class GeneMapper : IEntityTypeConfiguration<Gene>
    {
        public void Configure(EntityTypeBuilder<Gene> entity)
        {
            entity.ToTable("Genes", DomainDbSchemaNames.Genome);

            entity.HasKey(gene => gene.Id);

            entity.Property(gene => gene.Id)
                  .IsRequired()
                  .ValueGeneratedOnAdd();

            entity.Property(gene => gene.ChromosomeId)
                  .HasConversion<int>();


            entity.HasOne(gene => gene.Biotype)
                  .WithMany()
                  .HasForeignKey(gene => gene.BiotypeId);
        }
    }
}
