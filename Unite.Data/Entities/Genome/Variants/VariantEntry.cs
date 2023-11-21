namespace Unite.Data.Entities.Genome.Variants;

public abstract record VariantEntry<TVariant> : Entities.Base.AnalysisFeatureEntry<Specimens.Analysis.AnalysedSample, Specimens.Analysis.Analysis, Specimens.Specimen, TVariant>
    where TVariant : Variant
{    
}
