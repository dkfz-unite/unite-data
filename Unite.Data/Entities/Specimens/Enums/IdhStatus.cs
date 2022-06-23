using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Enums;

/// <summary>
/// IDH
/// </summary>
public enum IdhStatus
{
    /// <summary>
    /// Wild Type
    /// </summary>
    [EnumMember(Value = "Wild Type")]
    WildType = 1,

    /// <summary>
    /// Mutant
    /// </summary>
    [EnumMember(Value = "Mutant")]
    Mutant = 2
}
