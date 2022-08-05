namespace Unite.Data.Entities.Genome.Variants.SSM;

public class AffectedTranscript
{
    public long VariantId { get; set; }
    public int TranscriptId { get; set; }

    public int? CDNAStart { get; set; }
    public int? CDNAEnd { get; set; }
    public int? CDSStart { get; set; }
    public int? CDSEnd { get; set; }
    public int? ProteinStart { get; set; }
    public int? ProteinEnd { get; set; }
    public string AminoAcidChange { get; set; }
    public string CodonChange { get; set; }
    public AffectedTranscriptConsequence[] Concequences { get; set; }

    public virtual Mutation Variant { get; set; }
    public virtual Transcript Transcript { get; set; }
}
