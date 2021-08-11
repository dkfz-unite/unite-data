using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    public static class ProteinModelBuilder
    {
        public static void BuildProteinModel(this ModelBuilder modelBuilder)
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
