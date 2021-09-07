using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    internal static class ProteinModelBuilder
    {
        internal static void BuildProteinModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Protein>(entity =>
            {
                entity.ToTable("Proteins");

                entity.HasKey(protein => protein.Id);

                entity.Property(protein => protein.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();
            });
        }
    }
}
