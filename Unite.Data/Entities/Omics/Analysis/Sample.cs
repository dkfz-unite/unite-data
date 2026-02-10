using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Unite.Data.Entities.Specimens;

namespace Unite.Data.Entities.Omics.Analysis;

public record Sample : Base.Sample<Specimen, Analysis>
{
    [Column("matched_sample_id")]
    public int? MatchedSampleId { get; set; }

    /// <summary>
    /// Reference genome (only grch37 is allowed for DNA samples).
    /// </summary>
    [Column("genome")]
    public string Genome { get; set; }

    /// <summary>
    /// Percent of tumor cells in the sample (TCC - tumor cells content).
    /// </summary>
    [Column("purity")]
    public double? Purity { get; set; }

    /// <summary>
    /// Number of complete chromosomal sets in cells of the sample.
    /// </summary>
    [Column("ploidy")]
    public double? Ploidy { get; set; }

    /// <summary>
    /// Number of cells in the sample (for single cell sequencing).
    /// </summary>
    [Column("cells")]
    public int? Cells { get; set; }


    public virtual Sample MatchedSample { get; set; }

    public virtual ICollection<SampleResource> Resources { get; set; }
    public virtual ICollection<Dna.Sm.VariantEntry> SmEntries { get; set; }
    public virtual ICollection<Dna.Cnv.VariantEntry> CnvEntries { get; set; }
    public virtual ICollection<Dna.Sv.VariantEntry> SvEntries { get; set; }
    public virtual ICollection<Rna.GeneExpression> GeneExpressions { get; set; }
    public virtual ICollection<CnvProfile> CnvProfiles { get; set; }
}
