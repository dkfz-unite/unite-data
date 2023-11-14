using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Services.Models;

using Parameters = System.Collections.Generic.Dictionary<string, string>;

namespace Unite.Data.Services.Mappers.Base;

internal abstract class AnalysisMapper<TAnalysis, TAnalysisType> : IEntityTypeConfiguration<TAnalysis>
    where TAnalysis : Entities.Base.Analysis<TAnalysisType>
    where TAnalysisType : struct, Enum
{
    protected static readonly JsonSerializerOptions _options = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    protected static readonly Expression<Func<Parameters, string>> _serialize = value => JsonSerializer.Serialize<Parameters>(value, _options);
    protected static readonly Expression<Func<string, Parameters>> _deserialize = value => JsonSerializer.Deserialize<Parameters>(value, _options);

    public abstract string TableName { get; }
    public abstract string SchemaName { get; }


    public virtual void Configure(EntityTypeBuilder<TAnalysis> entity)
    {
        entity.ToTable(TableName, SchemaName);

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


        entity.HasOne<EnumValue<TAnalysisType>>()
              .WithMany()
              .HasForeignKey(analysis => analysis.TypeId);
    }
}
