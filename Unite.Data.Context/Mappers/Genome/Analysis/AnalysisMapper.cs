using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Unite.Data.Context.Mappers.Genome.Analysis;

internal class AnalysisMapper : Base.AnalysisMapper<Data.Entities.Genome.Analysis.Analysis, Data.Entities.Genome.Analysis.Enums.AnalysisType>
{
    public override void Configure(EntityTypeBuilder<Data.Entities.Genome.Analysis.Analysis> entity)
    {
        base.Configure(entity);
    }
}
