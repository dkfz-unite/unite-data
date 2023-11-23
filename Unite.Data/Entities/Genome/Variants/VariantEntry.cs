using Unite.Data.Entities.Genome.Analysis;

namespace Unite.Data.Entities.Genome.Variants;

/// <summary>
/// Variant occurrence.
/// </summary>
/// <typeparam name="TVariant">Variant type.</typeparam>
public abstract record VariantEntry<TVariant> : Base.AnalysedSampleEntry<AnalysedSample, TVariant, long>
    where TVariant : Variant
{
}
