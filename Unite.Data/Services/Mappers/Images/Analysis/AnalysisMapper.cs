using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Unite.Data.Services.Mappers.Images.Analysis;

internal class AnalysisMapper : Base.AnalysisMapper<Entities.Images.Analysis.Analysis, Entities.Images.Analysis.Enums.AnalysisType>
{
    public override void Configure(EntityTypeBuilder<Entities.Images.Analysis.Analysis> entity)
    {
        base.Configure(entity);   
    }
}
