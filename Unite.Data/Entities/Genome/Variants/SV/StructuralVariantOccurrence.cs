using Unite.Data.Entities.Genome.Analysis;

namespace Unite.Data.Entities.Genome.Variants.SV;

public class StructuralVariantOccurrence
{
    public long VariantId { get; set; }
    public int AnalysedSampleId { get; set; }

    public virtual StructuralVariant Variant { get; set; }
    public virtual AnalysedSample AnalysedSample { get; set; }
}
