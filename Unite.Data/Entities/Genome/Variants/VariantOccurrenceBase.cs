using Unite.Data.Entities.Genome.Analysis;

namespace Unite.Data.Entities.Genome.Variants;

/// <summary>
/// Variant occurrence
/// </summary>
/// <typeparam name="T">Variant type</typeparam>
public abstract class VariantOccurrenceBase<T> where T : VariantBase
{
    public long VariantId { get; set; }
    public int AnalysedSampleId { get; set; }

    public virtual T Variant { get; set; }
    public virtual AnalysedSample AnalysedSample { get; set; }
}
