using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Entities.Omics.Analysis.Dna.Cnv;
using Unite.Data.Entities.Omics.Enums;

namespace Unite.Data.Context.Mappers.Omics.Analysis.Dna.Cnv;

internal class ProfileMapper: EntityMapper<Profile>
{
    protected override string SchemaName => DomainDbSchemaNames.Omics;
    protected override string TableName => "cnv_profile";

    public override void Configure(EntityTypeBuilder<Profile> entity)
    {
        base.Configure(entity);

        entity.Property(cnvProfile => cnvProfile.ChromosomeId)
              .IsRequired()
              .HasConversion<int>();

        entity.Property(cnvProfile => cnvProfile.ChromosomeArmId)
              .IsRequired()
              .HasConversion<int>();


        entity.HasOne<EnumEntity<Chromosome>>()
            .WithMany()
            .HasForeignKey(cnvProfile => cnvProfile.ChromosomeId);
        
        entity.HasOne<EnumEntity<ChromosomeArm>>()
            .WithMany()
            .HasForeignKey(cnvProfile => cnvProfile.ChromosomeArmId);
        
        entity.HasOne(cnvProfile => cnvProfile.Sample)
            .WithMany(sample => sample.CnvProfiles)
            .HasForeignKey(cnvProfile => cnvProfile.SampleId);
    }
}
