using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Base;
using Unite.Data.Services.Models;

using Parameters = System.Collections.Generic.Dictionary<string, string>;

namespace Unite.Data.Services.Mappers.Base;

internal abstract class AnalysisMapper<TAnalysis, TAnalysisType> : IEntityTypeConfiguration<TAnalysis>
    where TAnalysis : Analysis<TAnalysisType>
    where TAnalysisType : struct, Enum
{
    private static readonly JsonSerializerOptions _options = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    private static readonly Expression<Func<Parameters, string>> _serialize = value => JsonSerializer.Serialize<Parameters>(value, _options);
    private static readonly Expression<Func<string, Parameters>> _deserialize = value => JsonSerializer.Deserialize<Parameters>(value, _options);

    protected virtual string TableName => "Analyses";

    public virtual void Configure(EntityTypeBuilder<TAnalysis> entity)
    {
        entity.ToTable(TableName);

        entity.HasKey(analysis => analysis.Id);

        entity.Property(analysis => analysis.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(analysis => analysis.ReferenceId)
              .HasMaxLength(255);

        entity.Property(analysis => analysis.TypeId)
              .IsRequired()
              .HasConversion<int>();

        entity.Property(analysis => analysis.Parameters)
              .HasConversion(_serialize, _deserialize);


        entity.HasOne<EnumValue<TAnalysisType>>()
              .WithMany()
              .HasForeignKey(analysis => analysis.TypeId);

        
        entity.HasIndex(analysis => analysis.ReferenceId);
    }
}
