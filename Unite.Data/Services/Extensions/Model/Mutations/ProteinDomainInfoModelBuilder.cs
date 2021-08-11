using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    public static class ProteinDomainInfoModelBuilder
    {
        public static void BuildProteinDomainInfoModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProteinDomainInfo>(entity =>
            {
                entity.ToTable("ProteinDomainInfo");

                entity.HasKey(proteinDomainInfo => proteinDomainInfo.ProteinDomainId);

                entity.Property(proteinDomainInfo => proteinDomainInfo.ProteinDomainId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(proteinDomainInfo => proteinDomainInfo.PfamId)
                      .HasMaxLength(255);


                entity.HasOne<ProteinDomain>()
                      .WithOne(proteinDomain => proteinDomain.Info)
                      .HasForeignKey<ProteinDomainInfo>(proteinDomainInfo => proteinDomainInfo.ProteinDomainId)
                      .IsRequired();


                entity.HasIndex(proteinDomainInfo => proteinDomainInfo.PfamId)
                      .IsUnique();
            });
        }
    }
}
