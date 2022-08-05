namespace Unite.Data.Entities.Genome.Variants.SV;

public class OverlappingGene
{
    public long Id { get; set; }

    public int GeneId { get; set; }
    public long VariantId { get; set; }

    public virtual Gene Gene { get; set; }
    public virtual StructuralVariant Variant { get; set; }
}
