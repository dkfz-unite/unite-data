using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome;
using Unite.Data.Entities.Genome.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Mappers.Genome;

internal class GeneMapper : IEntityTypeConfiguration<Gene>
{
    public void Configure(EntityTypeBuilder<Gene> entity)
    {
        entity.ToTable("Genes", DomainDbSchemaNames.Genome);

        entity.HasKey(gene => gene.Id);

        entity.HasAlternateKey(gene => gene.StableId);

        entity.Property(gene => gene.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(gene => gene.StableId)
              .IsRequired()
              .HasMaxLength(100);

        entity.Property(gene => gene.ChromosomeId)
              .HasConversion<int>();

        entity.Property(gene => gene.Biotype)
              .HasMaxLength(100);


        entity.HasOne<EnumValue<Chromosome>>()
              .WithMany()
              .HasForeignKey(gene => gene.ChromosomeId);
    }
}
