using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Enums;
using Unite.Data.Entities.Genome.Mutations;
using Unite.Data.Entities.Genome.Mutations.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Mappers.Genome.Mutations
{
    internal class MutationMapper : IEntityTypeConfiguration<Mutation>
    {
        public void Configure(EntityTypeBuilder<Mutation> entity)
        {
            entity.ToTable("Mutations", DomainDbSchemaNames.Genome);

            entity.HasKey(mutation => mutation.Id);

            entity.HasAlternateKey(mutation => mutation.Code);

            entity.Property(mutation => mutation.Id)
                  .IsRequired()
                  .ValueGeneratedOnAdd();

            entity.Property(mutation => mutation.Code)
                  .IsRequired()
                  .HasMaxLength(500);

            entity.Property(mutation => mutation.ChromosomeId)
                  .IsRequired()
                  .HasConversion<int>();

            entity.Property(mutation => mutation.Start)
                  .IsRequired();

            entity.Property(mutation => mutation.End)
                  .IsRequired();

            entity.Property(mutation => mutation.TypeId)
                  .IsRequired()
                  .HasConversion<int>();

            entity.Property(mutation => mutation.ReferenceBase)
                  .HasMaxLength(200);

            entity.Property(mutation => mutation.AlternateBase)
                  .HasMaxLength(200);


            entity.HasOne<EnumValue<Chromosome>>()
                  .WithMany()
                  .HasForeignKey(mutation => mutation.ChromosomeId);

            entity.HasOne<EnumValue<MutationType>>()
                  .WithMany()
                  .HasForeignKey(mutation => mutation.TypeId);
        }
    }
}
