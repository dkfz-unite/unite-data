using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Unite.Data.Context.Mappers.Images.Analysis;

internal class AnalysisMapper : Base.AnalysisMapper<Data.Entities.Images.Analysis.Analysis, Data.Entities.Images.Analysis.Enums.AnalysisType>
{
    public override void Configure(EntityTypeBuilder<Data.Entities.Images.Analysis.Analysis> entity)
    {
        base.Configure(entity);   
    }
}
