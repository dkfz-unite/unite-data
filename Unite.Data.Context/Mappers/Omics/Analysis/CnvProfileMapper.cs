using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base;
using Unite.Data.Entities.Omics.Analysis;

namespace Unite.Data.Context.Mappers.Omics.Analysis;

internal class CnvProfileMapper: EntityMapper<CnvProfile>
{
    protected override string SchemaName => DomainDbSchemaNames.Omics;
    protected override string TableName => "cnv_profile";

    public override void Configure(EntityTypeBuilder<CnvProfile> builder)
    {
        base.Configure(builder);
        
        builder.HasOne(cnvProfile => cnvProfile.Sample)
            .WithMany(sample => sample.CnvProfiles)
            .HasForeignKey(x => x.SampleId).OnDelete(DeleteBehavior.Restrict);
    }
}