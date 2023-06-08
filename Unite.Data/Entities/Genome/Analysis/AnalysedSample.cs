using Unite.Data.Entities.Genome.Transcriptomics;

namespace Unite.Data.Entities.Genome.Analysis;

public record AnalysedSample
{
    public int Id { get; set; }

    public int AnalysisId { get; set; }
    public int SampleId { get; set; }
    public int? MatchedSampleId { get; set; }

    /// <summary>
    /// Percent of tumor cells in the sample (TCC - tumor cells content)
    /// </summary>
    public double? Purity { get; set; }

    /// <summary>
    /// Number of complete chromosomal sets in cells of the sample
    /// </summary>
    public double? Ploidy { get; set; }


    public virtual Analysis Analysis { get; set; }
    public virtual Sample Sample { get; set; }
    public virtual Sample MatchedSample { get; set; }

    public virtual ICollection<Variants.SSM.VariantOccurrence> MutationOccurrences { get; set; }
    public virtual ICollection<Variants.CNV.VariantOccurrence> CopyNumberVariantOccurrences { get; set; }
    public virtual ICollection<Variants.SV.VariantOccurrence> StructuralVariantOccurrences { get; set; }
    public virtual ICollection<GeneExpression> GeneExpressions { get; set; }
}
