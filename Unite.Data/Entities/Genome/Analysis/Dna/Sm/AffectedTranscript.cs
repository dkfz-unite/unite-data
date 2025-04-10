using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Genome.Analysis.Dna.Sm;

/// <summary>
/// Simple mutation (SM) affected transcript.
/// </summary>
public record AffectedTranscript : VariantAffectedTranscript<Variant>
{
    [Column("protein_change")]
    public string ProteinChange { get; set; }
    [Column("codon_change")]
    public string CodonChange { get; set; }
}
