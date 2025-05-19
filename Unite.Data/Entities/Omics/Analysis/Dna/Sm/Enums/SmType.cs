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
    SNV = 1,

    /// <summary>
    /// Insertion.
    /// </summary>
    [EnumMember(Value = "INS")]
    INS = 2,

    /// <summary>
    /// Deletion.
    /// </summary>
    [EnumMember(Value = "DEL")]
    DEL = 3,

    /// <summary>
    /// Multiple Base Substitution.
    /// </summary>
    [EnumMember(Value = "MNV")]
    MNV = 4
}
