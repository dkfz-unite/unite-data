using System.Text.Json.Serialization;

namespace Unite.Data.Entities.Omics.Analysis.Dna;

/// <summary>
/// Variant consequence. <href>https://www.ensembl.org/info/genome/variation/prediction/predicted_data.html</href>
/// </summary>
public record Effect : IComparable<Effect>
{
    public static class Impacts
    {
        public const string High = "High";
        public const string Moderate = "Moderate";
        public const string Low = "Low";
        public const string Unknown = "Unknown";
    }

    public static readonly Dictionary<string, (string Impact, int Severity)> Effects = new()
    {
        { "transcript_ablation", (Impacts.High, 1) },
        { "splice_acceptor_variant", (Impacts.High, 2) },
        { "splice_donor_variant", (Impacts.High, 3) },
        { "stop_gained", (Impacts.High, 4) },
        { "frameshift_variant", (Impacts.High, 5) },
        { "stop_lost", (Impacts.High, 6) },
        { "start_lost", (Impacts.High, 7) },
        { "transcript_amplification", (Impacts.High, 8) },
        { "feature_elongation", (Impacts.High, 9) },
        { "feature_truncation", (Impacts.High, 10) },

        { "inframe_insertion", (Impacts.Moderate, 11) },
        { "inframe_deletion", (Impacts.Moderate, 12) },
        { "missense_variant", (Impacts.Moderate, 13) },
        { "protein_altering_variant", (Impacts.Moderate, 14) },

        { "splice_donor_5th_base_variant", (Impacts.Low, 15) },
        { "splice_region_variant", (Impacts.Low, 16) },
        { "splice_donor_region_variant", (Impacts.Low, 17) },
        { "splice_polypyrimidine_tract_variant", (Impacts.Low, 18) },
        { "incomplete_terminal_codon_variant", (Impacts.Low, 19) },
        { "start_retained_variant", (Impacts.Low, 20) },
        { "stop_retained_variant", (Impacts.Low, 21) },
        { "synonymous_variant", (Impacts.Low, 22) },

        { "coding_sequence_variant", (Impacts.Unknown, 23) },
        { "mature_miRNA_variant", (Impacts.Unknown, 24) },
        { "5_prime_UTR_variant", (Impacts.Unknown, 25) },
        { "3_prime_UTR_variant", (Impacts.Unknown, 26) },
        { "non_coding_transcript_exon_variant", (Impacts.Unknown, 27) },
        { "intron_variant", (Impacts.Unknown, 28) },
        { "NMD_transcript_variant", (Impacts.Unknown, 29) },
        { "non_coding_transcript_variant", (Impacts.Unknown, 30) },
        { "coding_transcript_variant", (Impacts.Unknown, 31) },
        { "upstream_gene_variant", (Impacts.Unknown, 32) },
        { "downstream_gene_variant", (Impacts.Unknown, 33) },
        { "TFBS_ablation", (Impacts.Unknown, 34) },
        { "TFBS_amplification", (Impacts.Unknown, 35) },
        { "TF_binding_site_variant", (Impacts.Unknown, 36) },
        { "regulatory_region_ablation", (Impacts.Unknown, 37) },
        { "regulatory_region_amplification", (Impacts.Unknown, 38) },
        { "regulatory_region_variant", (Impacts.Unknown, 39) },
        { "intergenic_variant", (Impacts.Unknown, 40) },
        { "sequence_variant", (Impacts.Unknown, 41) }
    };

    [JsonPropertyName("type")]
    public string Type { get; set; }
    [JsonPropertyName("impact")]
    public string Impact { get; set; }
    [JsonPropertyName("severity")]
    public int Severity { get; set; }


    public Effect()
    {

    }

    public Effect(string type)
    {
        var key = Effects.Keys.FirstOrDefault(key => key.Equals(type, StringComparison.InvariantCultureIgnoreCase));

        if (key != null)
        {
            Type = key;
            Impact = Effects[key].Impact;
            Severity = Effects[key].Severity;
        }
        else
        {
            Type = type;
        }
    }


    public int CompareTo(Effect other)
    {
        if (other == null)
            return 1;

        return Severity.CompareTo(other.Severity);
    }
}
