﻿using Unite.Data.Entities.Genome.Enums;

namespace Unite.Data.Entities.Genome.Variants;

public abstract class VariantBase
{
    /// <summary>
    /// Variant identifier
    /// </summary>
    public long Id { get; set; }

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
}