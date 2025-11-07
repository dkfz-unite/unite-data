using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Entities.Specimens;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens;

internal class MolecularDataMapper : IEntityTypeConfiguration<MolecularData>
{
    private static readonly JsonSerializerOptions _options = new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
    private static readonly Expression<Func<string[], string>> _serialize = value => JsonSerializer.Serialize<string[]>(value, _options);
    private static readonly Expression<Func<string, string[]>> _deserialize = value => JsonSerializer.Deserialize<string[]>(value, _options);
    
    public void Configure(EntityTypeBuilder<MolecularData> entity)
    {
        entity.ToTable("molecular_data", DomainDbSchemaNames.Specimens);

        entity.HasKey(molecularData => molecularData.SpecimenId);

        entity.Property(molecularData => molecularData.SpecimenId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(molecularData => molecularData.MgmtStatusId)
              .HasConversion<int>();

        entity.Property(molecularData => molecularData.IdhStatusId)
              .HasConversion<int>();

        entity.Property(molecularData => molecularData.IdhMutationId)
              .HasConversion<int>();

        entity.Property(molecularData => molecularData.GeneExpressionSubtypeId)
              .HasConversion<int>();

        entity.Property(molecularData => molecularData.MethylationSubtypeId)
              .HasConversion<int>();

        entity.Property(molecularData => molecularData.GeneKnockouts)
              .HasConversion(_serialize, _deserialize);


        entity.HasOne<EnumEntity<MgmtStatus>>()
              .WithMany()
              .HasForeignKey(molecularData => molecularData.MgmtStatusId);

        entity.HasOne<EnumEntity<IdhStatus>>()
              .WithMany()
              .HasForeignKey(molecularData => molecularData.IdhStatusId);

        entity.HasOne<EnumEntity<IdhMutation>>()
              .WithMany()
              .HasForeignKey(molecularData => molecularData.IdhMutationId);

        entity.HasOne<EnumEntity<GeneExpressionSubtype>>()
              .WithMany()
              .HasForeignKey(molecularData => molecularData.GeneExpressionSubtypeId);

        entity.HasOne<EnumEntity<MethylationSubtype>>()
              .WithMany()
              .HasForeignKey(molecularData => molecularData.MethylationSubtypeId);


        entity.HasOne(molecularData => molecularData.Specimen)
              .WithOne(specimen => specimen.MolecularData)
              .HasForeignKey<MolecularData>(molecularData => molecularData.SpecimenId);
    }
}
