namespace Unite.Data.Entities.Genome.Variants;

public abstract record VariantEntry<TVariant> : Entities.Base.AnalysisEntityEntry<Specimens.Analysis.AnalysedSample, Specimens.Analysis.Analysis, Specimens.Specimen, TVariant, long>
    where TVariant : Variant
{    
}
