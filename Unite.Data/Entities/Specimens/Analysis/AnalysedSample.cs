using Unite.Data.Entities.Genome.Transcriptomics;

namespace Unite.Data.Entities.Specimens.Analysis;

public record AnalysedSample : Entities.Base.AnalysedSample<Analysis, Specimen>
{
    /// <summary>
    /// Percent of tumor cells in the sample (TCC - tumor cells content)
    /// </summary>
    public double? Purity { get; set; }

    /// <summary>
    /// Number of complete chromosomal sets in cells of the sample
    /// </summary>
    public double? Ploidy { get; set; }


    public virtual ICollection<Genome.Variants.SSM.VariantEntry> SsmEntries { get; set; }
    public virtual ICollection<Genome.Variants.CNV.VariantEntry> CnvEntries { get; set; }
    public virtual ICollection<Genome.Variants.SV.VariantEntry> SvEntries { get; set; }
    public virtual ICollection<BulkExpression> BulkExpressions { get; set; }
}
