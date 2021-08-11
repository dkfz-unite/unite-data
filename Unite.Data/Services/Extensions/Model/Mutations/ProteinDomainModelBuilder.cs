using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    public static class ProteinDomainModelBuilder
    {
        public static void BuildProteinDomainModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProteinDomain>(entity =>
            {
                entity.ToTable("ProteinDomains");

                entity.HasKey(proteinDomain => proteinDomain.Id);

                entity.Property(proteinDomain => proteinDomain.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(proteinDomain => proteinDomain.ProteinId)
                      .IsRequired()
                      .ValueGeneratedNever();


                entity.HasOne(proteinDomain => proteinDomain.Protein)
                      .WithMany(protein => protein.ProteinDomains)
                      .HasForeignKey(proteinDomain => proteinDomain.ProteinId);
            });
        }
    }
}
