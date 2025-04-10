using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Enums;

/// <summary>
/// MGMT.
/// </summary>
public enum MgmtStatus
{
    /// <summary>
    /// Unmethylated.
    /// </summary>
    [EnumMember(Value = "Unmethylated")]
    Unmethylated = 1,

    /// <summary>
    /// Methylated.
    /// </summary>
    [EnumMember(Value = "Methylated")]
    Methylated = 2,
}
