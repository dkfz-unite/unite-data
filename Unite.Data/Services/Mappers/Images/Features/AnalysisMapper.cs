using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Images.Features;
using Unite.Data.Entities.Images.Features.Enums;
using Unite.Data.Services.Models;

using Parameters = System.Collections.Generic.Dictionary<string, string>;

namespace Unite.Data.Services.Mappers.Images.Features;

internal class AnalysisMapper : IEntityTypeConfiguration<Analysis>
{
    private static readonly JsonSerializerOptions _options = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    private static readonly Expression<Func<Parameters, string>> _serialize = value => JsonSerializer.Serialize<Parameters>(value, _options);
    private static readonly Expression<Func<string, Parameters>> _deserialize = value => JsonSerializer.Deserialize<Parameters>(value, _options);

    public void Configure(EntityTypeBuilder<Analysis> entity)
    {
        entity.ToTable("Analyses", DomainDbSchemaNames.Images);

        entity.HasKey(analysis => analysis.Id);

        entity.Property(analysis => analysis.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(analysis => analysis.ReferenceId)
              .HasMaxLength(255);

        entity.Property(analysis => analysis.TypeId)
              .HasConversion<int>();

        entity.Property(analysis => analysis.Parameters)
              .HasConversion(_serialize, _deserialize);


        entity.HasOne<EnumValue<AnalysisType>>()
              .WithMany()
              .HasForeignKey(analysis => analysis.TypeId);


        entity.HasIndex(analysis => analysis.ReferenceId);
    }
}
