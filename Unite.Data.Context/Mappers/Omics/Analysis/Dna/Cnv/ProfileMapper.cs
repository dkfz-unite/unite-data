using Microsoft.EntityFrameworkCore;
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

    public override void Configure(EntityTypeBuilder<Profile> builder)
    {
        base.Configure(builder);
        
        builder.HasOne(cnvProfile => cnvProfile.Sample)
            .WithMany(sample => sample.CnvProfiles)
            .HasForeignKey(x => x.SampleId).OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne<EnumEntity<Chromosome>>()
            .WithMany()
            .HasForeignKey(x => x.Chromosome);
        
        builder.HasOne<EnumEntity<ChromosomeArm>>()
            .WithMany()
            .HasForeignKey(x => x.ChromosomeArm);
        
        builder.Property(x => x.Chromosome).HasColumnName("chromosome");
        builder.Property(x => x.ChromosomeArm).HasColumnName("chromosome_arm");
        builder.Property(x => x.Gain).HasColumnName("gain");
        builder.Property(x => x.Loss).HasColumnName("loss");
        builder.Property(x => x.Neutral).HasColumnName("neutral");
        builder.Property(x => x.SampleId).HasColumnName("sample_id");
    }
}