using Unite.Data.Entities.Genome.Enums;

namespace Unite.Data.Entities.Genome.Variants.SV;

/// <summary>
/// Structural Variant (SV)
/// </summary>
public class StructuralVariant
{
    public long Id { get; set; }

    public Chromosome ChromosomeId { get; set; }
    public double Start { get; set; }
    public double End { get; set; }

    public Chromosome? NewChromosomeId { get; set; }
    public double? NewStart { get; set; }
    public double? NewEnd { get; set; }

    public virtual ICollection<StructuralVariantOccurrence> Occurrences { get; set; }
    public virtual ICollection<OverlappingGene> OverlappingGenes { get; set; }
}
