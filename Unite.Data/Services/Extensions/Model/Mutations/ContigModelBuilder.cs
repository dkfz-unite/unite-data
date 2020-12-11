using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    public static class ContigModelBuilder
    {
        public static void BuildContigModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contig>(entity =>
            {
                entity.ToTable("Contigs");

                entity.HasKey(contig => contig.Id);

                entity.Property(contig => contig.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(contig => contig.Value)
                      .IsRequired()
                      .HasMaxLength(500);


                entity.HasIndex(contig => contig.Value)
                      .IsUnique();
            });
        }
    }
}
