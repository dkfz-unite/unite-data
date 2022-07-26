using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens;

namespace Unite.Data.Services.Mappers.Specimens;

public class DrugScreeningMapper : IEntityTypeConfiguration<DrugScreening>
{
    private static readonly JsonSerializerOptions _serializerOptions = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

    public void Configure(EntityTypeBuilder<DrugScreening> entity)
    {
        entity.ToTable("DrugScreenings", DomainDbSchemaNames.Specimens);

        entity.HasKey(drugScreening => drugScreening.Id);

        entity.Property(drugScreening => drugScreening.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(drugScreening => drugScreening.SpecimenId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(drugScreening => drugScreening.DrugId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(drugScreening => drugScreening.Inhibition)
              .HasConversion(
                value => JsonSerializer.Serialize<double[]>(value, _serializerOptions),
                value => JsonSerializer.Deserialize<double[]>(value, _serializerOptions)
              );


        entity.HasOne<Specimen>()
              .WithMany(specimen => specimen.DrugScreenings)
              .HasForeignKey(drugScreening => drugScreening.SpecimenId);

        entity.HasOne(drugScreening => drugScreening.Drug)
              .WithMany()
              .HasForeignKey(drugScreening => drugScreening.DrugId);
    }
}
