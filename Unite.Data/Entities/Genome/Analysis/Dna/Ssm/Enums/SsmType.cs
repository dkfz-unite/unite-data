using System.Runtime.Serialization;

namespace Unite.Data.Entities.Genome.Analysis.Dna.Ssm.Enums;

/// <summary>
/// Simple somatic mutation type
/// </summary>
public enum SsmType
{
    /// <summary>
    /// Substitution
    /// </summary>
    [EnumMember(Value = "SNV")]
    SNV = 1,

    /// <summary>
    /// Insertion
    /// </summary>
    [EnumMember(Value = "INS")]
    INS = 2,

    /// <summary>
    /// Deletion
    /// </summary>
    [EnumMember(Value = "DEL")]
    DEL = 3,

    /// <summary>
    /// Multiple Base Substitution
    /// </summary>
    [EnumMember(Value = "MNV")]
    MNV = 4
}
