using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Analysis;
using Unite.Data.Entities.Specimens.Analysis.Drugs;

namespace Unite.Data.Context.Mappers.Specimens.Analysis.Drugs;

internal class DrugScreeningMapper : Base.SampleEntryMapper<DrugScreening, Sample, Drug>
{
    private static readonly JsonSerializerOptions _options = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    private static readonly Expression<Func<double[], string>> _serialize = value => JsonSerializer.Serialize<double[]>(value, _options);
    private static readonly Expression<Func<string, double[]>> _deserialize = value => JsonSerializer.Deserialize<double[]>(value, _options);

    protected override string SchemaName => DomainDbSchemaNames.Specimens;
    protected override string TableName => "DrugScreenings";
    protected override string EntityColumnName => "DrugId";

    public override void Configure(EntityTypeBuilder<DrugScreening> entity)
    {
        base.Configure(entity);

        entity.Property(drugScreening => drugScreening.Doses)
              .HasConversion(_serialize, _deserialize);

        entity.Property(drugScreening => drugScreening.Responses)
              .HasConversion(_serialize, _deserialize);


        entity.HasOne(drugScreening => drugScreening.Sample)
              .WithMany(sample => sample.DrugScreenings)
              .HasForeignKey(drugScreening => drugScreening.SampleId);

        entity.HasOne(drugScreening => drugScreening.Entity)
              .WithMany()
              .HasForeignKey(drugScreening => drugScreening.EntityId);
    }
}
