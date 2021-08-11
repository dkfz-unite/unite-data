using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    public static class ProteinInfoModelBuilder
    {
        public static void BuildProteinInfoModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProteinInfo>(entity =>
            {
                entity.ToTable("ProteinInfo");

                entity.HasKey(proteinInfo => proteinInfo.ProteinId);

                entity.Property(proteinInfo => proteinInfo.ProteinId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(proteinInfo => proteinInfo.EnsemblId)
                      .HasMaxLength(255);


                entity.HasOne<Protein>()
                      .WithOne(protein => protein.Info)
                      .HasForeignKey<ProteinInfo>(proteinInfo => proteinInfo.ProteinId)
                      .IsRequired();


                entity.HasIndex(proteinInfo => proteinInfo.EnsemblId)
                      .IsUnique();
            });
        }
    }
}
