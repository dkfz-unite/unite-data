using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Enums;

public enum TertMutation
{
    /// <summary>
    /// C228T.
    /// </summary>
    [EnumMember(Value = "C228T")]
    C228T = 1,

    /// <summary>
    /// C250T.
    /// </summary>
    [EnumMember(Value = "C250T")]
    C250T = 2
}
