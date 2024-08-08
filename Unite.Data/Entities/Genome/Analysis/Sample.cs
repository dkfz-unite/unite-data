using Unite.Data.Entities.Specimens;

namespace Unite.Data.Entities.Genome.Analysis;

public record Sample : Base.Sample<Specimen, Analysis>
{
    public int? MatchedSampleId { get; set; }

    /// <summary>
    /// Reference genome (only grch37 is allowed for DNA samples).
    /// </summary>
    public string Genome { get; set; }

    /// <summary>
    /// Percent of tumor cells in the sample (TCC - tumor cells content).
    /// </summary>
    public double? Purity { get; set; }

    /// <summary>
    /// Number of complete chromosomal sets in cells of the sample.
    /// </summary>
    public double? Ploidy { get; set; }

    /// <summary>
    /// Number of cells in the sample (for single cell sequencing).
    /// </summary>
    public int? Cells { get; set; }


    public virtual Sample MatchedSample { get; set; }

    public virtual ICollection<SampleResource> Resources { get; set; }
    public virtual ICollection<Dna.Ssm.VariantEntry> SsmEntries { get; set; }
    public virtual ICollection<Dna.Cnv.VariantEntry> CnvEntries { get; set; }
    public virtual ICollection<Dna.Sv.VariantEntry> SvEntries { get; set; }
    public virtual ICollection<Rna.GeneExpression> GeneExpressions { get; set; }
}
