using System.Runtime.Serialization;

namespace Unite.Data.Entities.Genome.Analysis.Dna.Sv.Enums;

/// <summary>
/// Structural variant type.
/// </summary>
public enum SvType
{
    /// <summary>
    /// Duplication.
    /// </summary>
    [EnumMember(Value = "DUP")]
    DUP = 1,

    /// <summary>
    /// Tandem duplication.
    /// </summary>
    [EnumMember(Value = "TDUP")]
    TDUP = 2,

    /// <summary>
    /// Insertion.
    /// </summary>
    [EnumMember(Value = "INS")]
    INS = 3,

    /// <summary>
    /// Deletion.
    /// </summary>
    [EnumMember(Value = "DEL")]
    DEL = 4,

    /// <summary>
    /// Inversion.
    /// </summary>
    [EnumMember(Value = "INV")]
    INV = 5,

    /// <summary>
    /// Intra-chromosomal translocation.
    /// </summary>
    [EnumMember(Value = "ITX")]
    ITX = 6,

    /// <summary>
    /// Inter-chromosomal translocation.
    /// </summary>
    [EnumMember(Value = "CTX")]
    CTX = 7,

    /// <summary>
    /// Complex.
    /// </summary>
    [EnumMember(Value = "COM")]
    COM = 8
}
