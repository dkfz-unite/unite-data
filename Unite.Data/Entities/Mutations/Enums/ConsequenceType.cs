using System.Runtime.Serialization;

namespace Unite.Data.Entities.Mutations.Enums
{
    public enum ConsequenceType
    {
        /// <summary>
        /// Transcript ablation
        /// </summary>
        [EnumMember(Value = "transcript_ablation")]
        TranscriptAblation = 1,

        /// <summary>
        /// Splice acceptor variant
        /// </summary>
        [EnumMember(Value = "splice_acceptor_variant")]
        SpliceAcceptor = 2,

        /// <summary>
        /// Splice donor variant
        /// </summary>
        [EnumMember(Value = "splice_donor_variant")]
        SpliceDonor = 3,

        /// <summary>
        /// Stop gained
        /// </summary>
        [EnumMember( Value = "stop_gained")]
        StopGained = 4,

        /// <summary>
        /// Frameshift variant
        /// </summary>
        [EnumMember(Value = "frameshift_variant")]
        Frameshift = 5,

        /// <summary>
        /// Stop lost
        /// </summary>
        [EnumMember(Value = "stop_lost")]
        StopLost = 6,

        /// <summary>
        /// Start lost
        /// </summary>
        [EnumMember(Value = "start_lost")]
        StartLost = 7,

        /// <summary>
        /// Transcript amplification
        /// </summary>
        [EnumMember(Value = "transcript_amplification")]
        TranscriptAmplification = 8,

        /// <summary>
        /// Inframe insertion
        /// </summary>
        [EnumMember(Value = "inframe_insertion")]
        InframeInsertion = 9,

        /// <summary>
        /// Inframe deletion
        /// </summary>
        [EnumMember(Value = "inframe_deletion")]
        InframeDeletion = 10,

        /// <summary>
        /// Missense variant
        /// </summary>
        [EnumMember(Value = "missense_variant")]
        Missense = 11,

        /// <summary>
        /// Protein altering variant
        /// </summary>
        [EnumMember(Value = "protein_altering_variant")]
        ProteinAltering = 12,

        /// <summary>
        /// Splice region variant
        /// </summary>
        [EnumMember(Value = "splice_region_variant")]
        SpliceRegion = 13,

        /// <summary>
        /// Incomplete terminal codon variant
        /// </summary>
        [EnumMember(Value = "incomplete_terminal_codon_variant")]
        IncompleteTerminalCodon = 14,

        /// <summary>
        /// Start retained variant
        /// </summary>
        [EnumMember(Value = "start_retained_variant")]
        StartRetained = 15,

        /// <summary>
        /// Stop retained variant
        /// </summary>
        [EnumMember(Value = "stop_retained_variant")]
        StopRetained = 16,

        /// <summary>
        /// Synonymous variant
        /// </summary>
        [EnumMember(Value = "synonymous_variant")]
        Synonymous = 17,

        /// <summary>
        /// Coding sequence variant
        /// </summary>
        [EnumMember(Value = "coding_sequence_variant")]
        CodingSequence = 18,

        /// <summary>
        /// Mature miRNA variant
        /// </summary>
        [EnumMember(Value = "mature_miRNA_variant")]
        MatureMiRNA = 19,

        /// <summary>
        /// 5 prime UTR variant
        /// </summary>
        [EnumMember(Value = "5_prime_UTR_variant")]
        UTR5 = 20,

        /// <summary>
        /// 3 prime UTR variant
        /// </summary>
        [EnumMember(Value = "3_prime_UTR_variant")]
        UTR3 = 21,

        /// <summary>
        /// Non coding transcript exon variant
        /// </summary>
        [EnumMember(Value = "non_coding_transcript_exon_variant")]
        NonCodingTranscriptExon = 22,

        /// <summary>
        /// Intron variant
        /// </summary>
        [EnumMember(Value = "intron_variant")]
        Intron = 23,

        /// <summary>
        /// NMD transcript variant
        /// </summary>
        [EnumMember(Value = "NMD_transcript_variant")]
        NmdTranscript = 24,

        /// <summary>
        /// Non coding transcript variant
        /// </summary>
        [EnumMember(Value = "non_coding_transcript_variant")]
        NonCodingTranscript = 25,

        /// <summary>
        /// Upstream gene variant
        /// </summary>
        [EnumMember(Value = "upstream_gene_variant")]
        Upstream = 26,

        /// <summary>
        /// Downstream gene variant
        /// </summary>
        [EnumMember(Value = "downstream_gene_variant")]
        Downstream = 27,

        /// <summary>
        /// TFBS ablation
        /// </summary>
        [EnumMember(Value = "TFBS_ablation")]
        TfbsAblation = 28,

        /// <summary>
        /// TFBS amplification
        /// </summary>
        [EnumMember(Value = "TFBS_amplification")]
        TfbsAmplification = 29,

        /// <summary>
        /// TF binding site variant
        /// </summary>
        [EnumMember(Value = "TF_binding_site_variant")]
        TfBindingSite = 30,

        /// <summary>
        /// Regulatory region ablation
        /// </summary>
        [EnumMember(Value = "regulatory_region_ablation")]
        RegulatoryRegionAblation = 31,

        /// <summary>
        /// Regulatory region amplification
        /// </summary>
        [EnumMember(Value = "regulatory_region_amplification")]
        RegulatoryRegionAmplification = 32,

        /// <summary>
        /// Feature elongation
        /// </summary>
        [EnumMember(Value = "feature_elongation")]
        FeatureElongation = 33,

        /// <summary>
        /// Regulatory region variant
        /// </summary>
        [EnumMember(Value = "regulatory_region_variant")]
        RegulatoryRegion = 34,

        /// <summary>
        /// Feature truncation
        /// </summary>
        [EnumMember(Value = "feature_truncation")]
        FeatureTruncation = 35,

        /// <summary>
        /// Intergenic variant
        /// </summary>
        [EnumMember(Value = "intergenic_variant")]
        Intergenic = 36
    }
}
