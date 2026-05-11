using System.ComponentModel;
using System.Runtime.Serialization;

namespace Unite.Data.Entities.Omics.Analysis.Dna.Sv.Enums;

/// <summary>
/// Structural variant type.
/// </summary>
public enum SvType
{
    /// <summary>
    /// Duplication.
    /// </summary>
    [EnumMember(Value = "DUP")]
    [Description("Duplication")]
    DUP = 1,

    /// <summary>
    /// Tandem duplication.
    /// </summary>
    [EnumMember(Value = "TDUP")]
    [Description("Tandem duplication")]
    TDUP = 2,

    /// <summary>
    /// Insertion.
    /// </summary>
    [EnumMember(Value = "INS")]
    [Description("Insertion")]
    INS = 3,

    /// <summary>
    /// Deletion.
    /// </summary>
    [EnumMember(Value = "DEL")]
    [Description("Deletion")]
    DEL = 4,

    /// <summary>
    /// Inversion.
    /// </summary>
    [EnumMember(Value = "INV")]
    [Description("Inversion")]
    INV = 5,

    /// <summary>
    /// Intra-chromosomal translocation.
    /// </summary>
    [EnumMember(Value = "ITX")]
    [Description("Intra-choromosmal translocation")]
    ITX = 6,

    /// <summary>
    /// Inter-chromosomal translocation.
    /// </summary>
    [EnumMember(Value = "CTX")]
    [Description("Inter-chromosomal translocation")]
    CTX = 7,

    /// <summary>
    /// Complex.
    /// </summary>
    [EnumMember(Value = "COM")]
    [Description("Complex rearrangement")]
    COM = 8
}
