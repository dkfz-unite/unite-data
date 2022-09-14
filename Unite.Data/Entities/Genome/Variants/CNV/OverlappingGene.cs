namespace Unite.Data.Entities.Genome.Variants.CNV
{
    public class OverlappingGene
    {
        public long Id { get; set; }

        public int GeneId { get; set; }
        public long VariantId { get; set; }

        public virtual Gene Gene { get; set; }
        public virtual CopyNumberVariant Variant { get; set; }
    }
}
