namespace Unite.Data.Entities.Genome.Analysis.Dna;

/// <summary>
/// Variant affected feature
/// </summary>
/// <typeparam name="TVariant">Variant type</typeparam>
/// <typeparam name="TFeature">Feature type</typeparam>
public abstract record VariantAffectedFeature<TVariant, TFeature>
    where TVariant : Variant
    where TFeature : Feature
{
    public int VariantId { get; set; }
    public int FeatureId { get; set; }

    public Effect[] Effects { get; set; }

    public virtual TVariant Variant { get; set; }
    public virtual TFeature Feature { get; set; }
}
