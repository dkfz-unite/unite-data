namespace Unite.Data.Entities.Genome.Analysis.Dna;

public abstract record VariantAffectedTranscript<TVariant> : VariantAffectedFeature<TVariant, Transcript>
    where TVariant : Variant
{
    public int? Distance { get; set; }
    public int? OverlapBpNumber { get; set; }
    public double? OverlapPercentage { get; set; }

    public int? CDNAStart { get; set; }
    public int? CDNAEnd { get; set; }
    public int? CDSStart { get; set; }
    public int? CDSEnd { get; set; }
    public int? ProteinStart { get; set; }
    public int? ProteinEnd { get; set; }
}
