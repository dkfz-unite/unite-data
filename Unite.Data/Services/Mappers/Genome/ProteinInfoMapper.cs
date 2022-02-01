using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome;

namespace Unite.Data.Services.Mappers.Genome
{
    internal class ProteinInfoMapper : IEntityTypeConfiguration<ProteinInfo>
    {
        public void Configure(EntityTypeBuilder<ProteinInfo> entity)
        {
            entity.ToTable("ProteinInfo", DomainDbSchemaNames.Genome);

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
        }
    }
}
