namespace Unite.Data.Entities.Genome.Variants;

/// <summary>
/// Variant affected regulatory feature
/// </summary>
/// <typeparam name="T">Variant type</typeparam>
public abstract class AffectedRegulationBase<T> where T : VariantBase
{
    public long VariantId { get; set; }
    public int RegulationId { get; set; }

    public Consequence[] Consequences { get; set; }

    public virtual T Variant { get; set; }
    //public virtual Regulation Regulation { get; set; }
}
