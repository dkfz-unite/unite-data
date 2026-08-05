using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities;

namespace Unite.Data.Context.Mappers;

public class DataUserMapper : IEntityTypeConfiguration<DataUser>
{
    public void Configure(EntityTypeBuilder<DataUser> entity)
    {
        entity.ToTable("data_user", DomainDbSchemaNames.Donors);

        entity.HasKey(user => user.Id);

        entity.Property(user => user.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        entity.Property(user => user.UserId);
    }
}