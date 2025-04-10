using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Genome.Analysis.Dna;

/// <summary>
/// Variant affected feature.
/// </summary>
/// <typeparam name="TVariant">Variant type</typeparam>
/// <typeparam name="TFeature">Feature type</typeparam>
public abstract record VariantAffectedFeature<TVariant, TFeature> : IComparable<VariantAffectedFeature<TVariant, TFeature>>
    
    where TVariant : Variant
    where TFeature : Feature
{
    [Column("variant_id")]
    public int VariantId { get; set; }
    [Column("feature_id")]
    public int FeatureId { get; set; }

    [Column("effects")]
    public Effect[] Effects { get; set; }

    [NotMapped]
    public Effect MostSevereEffect => Effects.Order().First();


    public virtual TVariant Variant { get; set; }
    public virtual TFeature Feature { get; set; }


    public int CompareTo(VariantAffectedFeature<TVariant, TFeature> other)
    {
        if (other == null)
            return 1;
        
        var thisEffect = Effects.Order().First();
        var otherEffect = other.Effects.Order().First();

        return thisEffect.CompareTo(otherEffect);
    }
}
