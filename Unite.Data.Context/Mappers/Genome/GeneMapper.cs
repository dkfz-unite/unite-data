using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Entities.Genome;
using Unite.Data.Entities.Genome.Enums;

namespace Unite.Data.Context.Mappers.Genome;

internal class GeneMapper : IEntityTypeConfiguration<Gene>
{
    public void Configure(EntityTypeBuilder<Gene> entity)
    {
        entity.ToTable("gene", DomainDbSchemaNames.Genome);

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


        entity.HasOne<EnumEntity<Chromosome>>()
              .WithMany()
              .HasForeignKey(gene => gene.ChromosomeId);
    }
}
