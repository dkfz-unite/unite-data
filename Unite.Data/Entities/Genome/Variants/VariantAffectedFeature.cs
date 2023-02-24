namespace Unite.Data.Entities.Genome.Variants;

/// <summary>
/// Variant affected feature
/// </summary>
/// <typeparam name="TVariant">Variant type</typeparam>
/// <typeparam name="TFeature">Feature type</typeparam>
public abstract class VariantAffectedFeature<TVariant, TFeature>
    where TVariant : Variant
    where TFeature : Feature
{
    public long VariantId { get; set; }
    public int FeatureId { get; set; }

    public Consequence[] Consequences { get; set; }

    public virtual TVariant Variant { get; set; }
    public virtual TFeature Feature { get; set; }
}
