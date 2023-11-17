using Unite.Data.Entities.Base;
using Unite.Data.Entities.Genome.Enums;

namespace Unite.Data.Entities.Genome.Variants;

public abstract record Variant : Entity<long>
{
    /// <summary>
    /// Chromosome
    /// </summary>
    public Chromosome ChromosomeId { get; set; }

    /// <summary>
    /// Chromosome region start
    /// </summary>
    public int Start { get; set; }

    /// <summary>
    /// Chromosome region end
    /// </summary>
    public int End { get; set; }

    /// <summary>
    /// Number of base pairs affected by the variant
    /// </summary>
    public int? Length { get; set; }
}
