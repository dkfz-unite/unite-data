namespace Unite.Data.Entities.Genome.Analysis.Dna;

public record Consequence
{
    private static class Impacts
    {
        public const string High = "High";
        public const string Moderate = "Moderate";
        public const string Low = "Low";
        public const string Unknown = "Unknown";
    }

    public static readonly Dictionary<string, (string Impact, int Severity)> Consequences = new()
    {
        { "transcript_ablation", (Impacts.High, 1) },
        { "splice_acceptor_variant", (Impacts.High, 2) },
        { "splice_donor_variant", (Impacts.High, 3) },
        { "stop_gained", (Impacts.High, 4) },
        { "frameshift_variant", (Impacts.High, 5) },
        { "stop_lost", (Impacts.High, 6) },
        { "start_lost", (Impacts.High, 7) },
        { "transcript_amplification", (Impacts.High, 8) },
        { "inframe_insertion", (Impacts.Moderate, 9) },
        { "inframe_deletion", (Impacts.Moderate, 10) },
        { "missense_variant", (Impacts.Moderate, 11) },
        { "protein_altering_variant", (Impacts.Moderate, 12) },
        { "splice_region_variant", (Impacts.Low, 13) },
        { "incomplete_terminal_codon_variant", (Impacts.Low, 14) },
        { "start_retained_variant", (Impacts.Low, 15) },
        { "stop_retained_variant", (Impacts.Low, 16) },
        { "synonymous_variant", (Impacts.Low, 17) },
        { "coding_sequence_variant", (Impacts.Unknown, 18) },
        { "mature_miRNA_variant", (Impacts.Unknown, 19) },
        { "5_prime_UTR_variant", (Impacts.Unknown, 20) },
        { "3_prime_UTR_variant", (Impacts.Unknown, 21) },
        { "non_coding_transcript_exon_variant", (Impacts.Unknown, 22) },
        { "intron_variant", (Impacts.Unknown, 23) },
        { "NMD_transcript_variant", (Impacts.Unknown, 24) },
        { "non_coding_transcript_variant", (Impacts.Unknown, 25) },
        { "upstream_gene_variant", (Impacts.Unknown, 26) },
        { "downstream_gene_variant", (Impacts.Unknown, 27) },
        { "TFBS_ablation", (Impacts.Unknown, 28) },
        { "TFBS_amplification", (Impacts.Unknown, 29) },
        { "TF_binding_site_variant", (Impacts.Unknown, 30) },
        { "regulatory_region_ablation", (Impacts.Moderate, 31) },
        { "regulatory_region_amplification", (Impacts.Unknown, 32) },
        { "feature_elongation", (Impacts.Unknown, 33) },
        { "regulatory_region_variant", (Impacts.Unknown, 34) },
        { "feature_truncation", (Impacts.Unknown, 35) },
        { "intergenic_variant", (Impacts.Unknown, 36) }
    };


    public string Type { get; set; }
    public string Impact { get; set; }
    public int Severity { get; set; }


    public Consequence()
    {

    }

    public Consequence(string type)
    {
        var key = Consequences.Keys.FirstOrDefault(key => key.Equals(type, StringComparison.InvariantCultureIgnoreCase));

        if (key != null)
        {
            Type = key;
            Impact = Consequences[key].Impact;
            Severity = Consequences[key].Severity;
        }
        else
        {
            Type = type;
        }
    }
}
