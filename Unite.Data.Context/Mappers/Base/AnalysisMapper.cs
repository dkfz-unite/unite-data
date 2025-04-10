using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Entities.Base;

using Parameters = System.Collections.Generic.Dictionary<string, string>;

namespace Unite.Data.Context.Mappers.Base;

internal abstract class AnalysisMapper<TAnalysis, TAnalysisType> : IEntityTypeConfiguration<TAnalysis>
    where TAnalysis : Analysis<TAnalysisType>
    where TAnalysisType : struct, Enum
{
    private static readonly JsonSerializerOptions _options = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    private static readonly Expression<Func<Parameters, string>> _serialize = value => JsonSerializer.Serialize<Parameters>(value, _options);
    private static readonly Expression<Func<string, Parameters>> _deserialize = value => JsonSerializer.Deserialize<Parameters>(value, _options);

    protected abstract string SchemaName { get; }
    protected virtual string TableName => "analysis";
    
    public virtual void Configure(EntityTypeBuilder<TAnalysis> entity)
    {
        entity.ToTable(TableName, SchemaName);

        entity.HasKey(analysis => analysis.Id);

        entity.Property(analysis => analysis.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

        entity.Property(analysis => analysis.TypeId)
              .IsRequired()
              .HasConversion<int>();

        entity.Property(analysis => analysis.Parameters)
              .HasConversion(_serialize, _deserialize);


        entity.HasOne<EnumEntity<TAnalysisType>>()
              .WithMany()
              .HasForeignKey(analysis => analysis.TypeId);
    }
}
