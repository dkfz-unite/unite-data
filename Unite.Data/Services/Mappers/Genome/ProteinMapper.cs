using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome;

namespace Unite.Data.Services.Mappers.Genome
{
    internal class ProteinMapper : IEntityTypeConfiguration<Protein>
    {
        public void Configure(EntityTypeBuilder<Protein> entity)
        {
            entity.ToTable("Proteins", DomainDbSchemaNames.Genome);

            entity.HasKey(protein => protein.Id);

            entity.Property(protein => protein.Id)
                  .IsRequired()
                  .ValueGeneratedOnAdd();
        }
    }
}
