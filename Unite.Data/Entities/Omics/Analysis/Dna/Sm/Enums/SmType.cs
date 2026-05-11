using System.ComponentModel;
using System.Runtime.Serialization;

namespace Unite.Data.Entities.Omics.Analysis.Dna.Sm.Enums;

/// <summary>
/// Simple mutation type.
/// </summary>
public enum SmType
{
    /// <summary>
    /// Substitution.
    /// </summary>
    [EnumMember(Value = "SNV")]
    [Description("Single Nucleotide Variant")]
    SNV = 1,

    /// <summary>
    /// Insertion.
    /// </summary>
    [EnumMember(Value = "INS")]
    [Description("Insertion")]
    INS = 2,

    /// <summary>
    /// Deletion.
    /// </summary>
    [EnumMember(Value = "DEL")]
    [Description("Deletion")]
    DEL = 3,

    /// <summary>
    /// Multiple Base Substitution.
    /// </summary>
    [EnumMember(Value = "MNV")]
    [Description("Multiple Nucleotide Variant")]
    MNV = 4
}
