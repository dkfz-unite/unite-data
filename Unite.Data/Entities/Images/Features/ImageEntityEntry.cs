using System.Numerics;

namespace Unite.Data.Entities.Images.Features;

public abstract record ImageEntityEntry<TEntity, T> : Base.AnalysisEntityEntry<Analysis.AnalysedSample, Analysis.Analysis, Image, TEntity, T>
    where TEntity : Base.Entity<T>
    where T : INumber<T>
{
}
