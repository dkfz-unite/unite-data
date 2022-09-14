using Unite.Data.Entities.Genome.Transcriptome;
using Unite.Data.Entities.Genome.Variants.CNV;
using Unite.Data.Entities.Genome.Variants.SSM;
using Unite.Data.Entities.Genome.Variants.SV;

namespace Unite.Data.Entities.Genome.Analysis;

public class AnalysedSample
{
    public int Id { get; set; }

    public int AnalysisId { get; set; }
    public int SampleId { get; set; }
    public int? MatchedSampleId { get; set; }

    public virtual Analysis Analysis { get; set; }
    public virtual Sample Sample { get; set; }
    public virtual Sample MatchedSample { get; set; }

    public virtual ICollection<MutationOccurrence> MutationOccurrences { get; set; }
    public virtual ICollection<CopyNumberVariantOccurrence> CopyNumberVariantOccurrences { get; set; }
    public virtual ICollection<StructuralVariantOccurrence> StructuralVariantOccurrences { get; set; }
    public virtual ICollection<TranscriptExpression> TranscriptExpressions { get; set; }
}
