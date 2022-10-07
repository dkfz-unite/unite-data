namespace Unite.Data.Entities.Genome.Variants;

/// <summary>
/// Variant affected motif feature
/// </summary>
/// <typeparam name="T">Variant type</typeparam>
public abstract class AffectedMotifBase<T> where T : VariantBase
{
    public long VariantId { get; set; }
    public int MotifId { get; set; }

    public Consequence[] Consequences { get; set; }

    public virtual T Variant { get; set; }
    //public virtual Motif Motif { get; set; }
}
