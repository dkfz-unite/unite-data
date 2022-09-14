using Unite.Data.Entities.Genome.Enums;

namespace Unite.Data.Entities.Genome.Variants.CNV;

/// <summary>
/// Copy Number Variant (CNV)
/// </summary>
public class CopyNumberVariant
{
    public long Id { get; set; }
    public Chromosome ChromosomeId { get; set; }
    public int Start { get; set; }
    public int End { get; set; }

    public virtual ICollection<CopyNumberVariantOccurrence> Occurrences { get; set; }
    public virtual ICollection<OverlappingGene> OverlappingGenes { get; set; }
}
