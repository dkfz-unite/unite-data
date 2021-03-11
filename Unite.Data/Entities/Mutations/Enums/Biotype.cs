using System.Runtime.Serialization;

namespace Unite.Data.Entities.Mutations.Enums
{
    public enum Biotype
    {
        /// <summary>
        /// IG gene
        /// </summary>
        [EnumMember(Value = "IG gene")]
        IG,

        /// <summary>
        /// Nonsense Mediated Decay
        /// </summary>
        [EnumMember(Value = "Nonsense Mediated Decay")]
        NonsenseMediatedDecay,

        /// <summary>
        /// Processed transcript
        /// </summary>
        [EnumMember(Value = "Processed transcript")]
        ProcessedTranscript,

        /// <summary>
        /// Protein coding
        /// </summary>
        [EnumMember(Value = "Protein coding")]
        ProteinCoding,

        /// <summary>
        /// Pseudogene
        /// </summary>
        [EnumMember(Value = "Pseudogene")]
        Pseudogene,

        /// <summary>
        /// Readthrough
        /// </summary>
        [EnumMember(Value = "Readthrough")]
        Readthrough,

        /// <summary>
        /// Stop codon readthrough
        /// </summary>
        [EnumMember(Value = "Stop codon readthrough")]
        StopCodonReadthrough,

        /// <summary>
        /// TEC
        /// </summary>
        [EnumMember(Value = "TEC")]
        TEC,

        /// <summary>
        /// TR gene
        /// </summary>
        [EnumMember(Value = "TR gene")]
        TR
    }
}
