using Unite.Data.Entities.Genome.Analysis;

namespace Unite.Data.Entities.Genome.Variants.CNV;

public class CopyNumberVariantOccurrence
{
    public long VariantId { get; set; }
    public int AnalysedSampleId { get; set; }

    public virtual CopyNumberVariant Variant { get; set; }
    public virtual AnalysedSample AnalysedSample { get; set; }
}
