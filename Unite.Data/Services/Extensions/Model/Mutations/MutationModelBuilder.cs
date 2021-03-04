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

                entity.HasAlternateKey(mutation => mutation.Code);

                entity.Property(mutation => mutation.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(mutation => mutation.Code)
                      .IsRequired()
                      .HasMaxLength(500);

                entity.Property(mutation => mutation.ChromosomeId)
                      .HasConversion<int>();
                      
                entity.Property(mutation => mutation.Start)
                      .IsRequired();

                entity.Property(mutation => mutation.End)
                      .IsRequired()
                      .HasDefaultValueSql($"[Start]");

                entity.Property(mutation => mutation.SequenceTypeId)
                      .IsRequired()
                      .HasConversion<int>();

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

                entity.HasOne<EnumValue<SequenceType>>()
                      .WithMany()
                      .HasForeignKey(mutation => mutation.SequenceTypeId);

                entity.HasOne<EnumValue<MutationType>>()
                      .WithMany()
                      .HasForeignKey(mutation => mutation.TypeId);
            });
        }
    }
}
