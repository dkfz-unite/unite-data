using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens;

namespace Unite.Data.Services.Mappers.Specimens;

public class DrugScreeningMapper : IEntityTypeConfiguration<DrugScreening>
{
    private static readonly JsonSerializerOptions _options = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    private static readonly Expression<Func<double[], string>> _serialize = value => JsonSerializer.Serialize<double[]>(value, _options);
    private static readonly Expression<Func<string, double[]>> _deserialize = value => JsonSerializer.Deserialize<double[]>(value, _options);


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

        entity.Property(drugScreening => drugScreening.Concentrations)
              .HasConversion(_serialize, _deserialize);

        entity.Property(drugScreening => drugScreening.Inhibitions)
              .HasConversion(_serialize, _deserialize);

        entity.Property(drugScreening => drugScreening.InhibitionsControl)
              .HasConversion(_serialize, _deserialize);

        entity.Property(drugScreening => drugScreening.InhibitionsSample)
              .HasConversion(_serialize, _deserialize);


        entity.HasOne<Specimen>()
              .WithMany(specimen => specimen.DrugScreenings)
              .HasForeignKey(drugScreening => drugScreening.SpecimenId);

        entity.HasOne(drugScreening => drugScreening.Drug)
              .WithMany()
              .HasForeignKey(drugScreening => drugScreening.DrugId);
    }
}
