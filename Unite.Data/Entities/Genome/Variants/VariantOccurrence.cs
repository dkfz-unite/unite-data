﻿using Unite.Data.Entities.Genome.Analysis;

namespace Unite.Data.Entities.Genome.Variants;

/// <summary>
/// Variant occurrence
/// </summary>
/// <typeparam name="TVariant">Variant type</typeparam>
public abstract class VariantOccurrence<TVariant>
    where TVariant : Variant
{
    public long Id { get; set; }
    public long VariantId { get; set; }
    public int AnalysedSampleId { get; set; }

    public virtual TVariant Variant { get; set; }
    public virtual AnalysedSample AnalysedSample { get; set; }
}
