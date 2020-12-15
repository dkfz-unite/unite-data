using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;
using Unite.Data.Entities.Mutations.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    public static class MutationModelBuilder
    {
        public static void BuildMutationModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mutation>(entity =>
            {
                entity.ToTable("Mutations");

                entity.HasKey(mutation => mutation.Id);

                entity.Property(mutation => mutation.Id)
                      .ValueGeneratedOnAdd();

                entity.Property(mutation => mutation.ReferenceId)
                      .HasMaxLength(100);

                entity.Property(mutation => mutation.ChromosomeId)
                      .HasConversion<int>();
                      
                entity.Property(mutation => mutation.Position)
                      .IsRequired();

                entity.Property(mutation => mutation.SequenceTypeId)
                      .IsRequired()
                      .HasConversion<int>();

                entity.Property(mutation => mutation.TypeId)
                      .HasConversion<int>();

                entity.Property(mutation => mutation.ReferenceAllele)
                      .HasMaxLength(500);

                entity.Property(mutation => mutation.AlternateAllele)
                      .HasMaxLength(500);


                entity.HasOne<EnumValue<Chromosome>>()
                      .WithMany()
                      .HasForeignKey(mutation => mutation.ChromosomeId);

                entity.HasOne<EnumValue<SequenceType>>()
                      .WithMany()
                      .HasForeignKey(mutation => mutation.SequenceTypeId);

                entity.HasOne<EnumValue<MutationType>>()
                      .WithMany()
                      .HasForeignKey(mutation => mutation.TypeId);


                entity.HasOne(mutation => mutation.Gene)
                      .WithMany(gene => gene.Mutations)
                      .HasForeignKey(mutation => mutation.GeneId);

                entity.HasOne(mutation => mutation.Contig)
                      .WithMany()
                      .HasForeignKey(mutation => mutation.ContigId);
            });
        }
    }
}
