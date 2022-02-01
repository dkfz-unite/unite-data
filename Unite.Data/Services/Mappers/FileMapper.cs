using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities;

namespace Unite.Data.Services.Mappers
{
    internal class FileMapper : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> entity)
        {
            entity.ToTable("Files", DomainDbSchemaNames.Common);

            entity.HasKey(file => file.Id);

            entity.Property(file => file.Id)
                  .IsRequired()
                  .ValueGeneratedOnAdd();

            entity.Property(file => file.Name)
                  .IsRequired();
        }
    }
}
