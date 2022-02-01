using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Donors.Clinical;

namespace Unite.Data.Services.Mappers.Donors.Clinical
{
    internal class TherrapyMapper : IEntityTypeConfiguration<Therapy>
    {
        public void Configure(EntityTypeBuilder<Therapy> entity)
        {
            entity.ToTable("Therapies", DomainDbSchemaNames.Donors);

            entity.HasKey(therapy => therapy.Id);

            entity.HasAlternateKey(therapy => therapy.Name);

            entity.Property(therapy => therapy.Id)
                  .IsRequired()
                  .ValueGeneratedOnAdd();

            entity.Property(therapy => therapy.Name)
                  .IsRequired()
                  .HasMaxLength(100);
        }
    }
}
