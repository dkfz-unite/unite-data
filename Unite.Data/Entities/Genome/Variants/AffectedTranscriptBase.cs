namespace Unite.Data.Entities.Genome.Variants;

/// <summary>
/// Variant affected transcript
/// </summary>
/// <typeparam name="T">Variant type</typeparam>
public abstract class AffectedTranscriptBase<T> where T : VariantBase
{
    public long VariantId { get; set; }
    public int TranscriptId { get; set; }

    public Consequence[] Consequences { get; set; }

    public virtual T Variant { get; set; }
    public virtual Transcript Transcript { get; set; }
}
