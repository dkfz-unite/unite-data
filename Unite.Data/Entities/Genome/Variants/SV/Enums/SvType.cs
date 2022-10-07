using System.Runtime.Serialization;

namespace Unite.Data.Entities.Genome.Variants.SV.Enums;

/// <summary>
/// Structural variant type
/// </summary>
public enum SvType
{
    /// <summary>
    /// Duplication
    /// </summary>
    [EnumMember(Value = "DUP")]
    DUP = 1,

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
    /// Inversion
    /// </summary>
    [EnumMember(Value = "INV")]
    INV = 4,

    /// <summary>
    /// Intra-chromosomal translocation
    /// </summary>
    [EnumMember(Value = "ITX")]
    ITX = 5,

    /// <summary>
    /// Inter-chromosomal translocation
    /// </summary>
    [EnumMember(Value = "CTX")]
    CTX = 6,

    /// <summary>
    /// Complex
    /// </summary>
    [EnumMember(Value = "COM")]
    COM = 7
}
