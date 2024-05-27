namespace Unite.Data.Entities.Genome.Analysis.Dna;

/// <summary>
/// Variant occurrence.
/// </summary>
/// <typeparam name="TVariant">Variant type.</typeparam>
public abstract record VariantEntry<TVariant> : Base.SampleEntry<Sample, TVariant>
    where TVariant : Variant
{
}
