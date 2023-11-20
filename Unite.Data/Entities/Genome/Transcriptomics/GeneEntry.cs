namespace Unite.Data.Entities.Genome.Transcriptomics;

public abstract record GeneEntry : Entities.Base.AnalysisEntityEntry<Specimens.Analysis.AnalysedSample, Specimens.Analysis.Analysis, Specimens.Specimen, Gene, int>
{
}
