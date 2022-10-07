using System.Runtime.Serialization;

namespace Unite.Data.Entities.Genome.Variants.CNV.Enums;

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
    /// Deletion
    /// </summary>
    [EnumMember(Value = "DEL")]
    DEL = 2,

    /// <summary>
    /// Intra-chromosomal translocation
    /// </summary>
    [EnumMember(Value = "ITX")]
    ITX = 3,

    /// <summary>
    /// Inter-chromosomal translocation
    /// </summary>
    [EnumMember(Value = "CTX")]
    CTX = 4
}
