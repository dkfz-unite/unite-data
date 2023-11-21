using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens;
using Unite.Data.Services.Mappers.Base;

namespace Unite.Data.Services.Mappers.Specimens;

internal class DrugScreeningMapper : SampleFeatureEntryMapper<DrugScreening, Drug>
{
    private static readonly JsonSerializerOptions _options = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    private static readonly Expression<Func<double[], string>> _serialize = value => JsonSerializer.Serialize<double[]>(value, _options);
    private static readonly Expression<Func<string, double[]>> _deserialize = value => JsonSerializer.Deserialize<double[]>(value, _options);

    public override string TableName => "DrugScreenings";
    public override string SchemaName => DomainDbSchemaNames.Specimens;

    public override string FeatureColumnName => "DrugId";
    public override string SampleColumnName => "SpecimenId";


    public override void Configure(EntityTypeBuilder<DrugScreening> entity)
    {
        base.Configure(entity);

        entity.Property(entry => entry.Concentration)
              .HasConversion(_serialize, _deserialize);

        entity.Property(entry => entry.Inhibition)
              .HasConversion(_serialize, _deserialize);

        entity.Property(entry => entry.ConcentrationLine)
              .HasConversion(_serialize, _deserialize);

        entity.Property(entry => entry.InhibitionLine)
              .HasConversion(_serialize, _deserialize);


        entity.HasOne(entry => entry.Sample)
              .WithMany(specimen => specimen.DrugScreenings)
              .HasForeignKey(entry => entry.SampleId);

        entity.HasOne(entry => entry.Feature)
              .WithMany()
              .HasForeignKey(entry => entry.FeatureId);
    }
}
