using System.ComponentModel;
using System.Runtime.Serialization;

namespace Unite.Data.Entities.Omics.Enums;

public enum ChromosomeArm
{
    /// <summary>
    /// Chromosome arm P (short arm).
    /// </summary>
    [EnumMember(Value = "P")]
    [Description("Short arm")]
    P = 1,

    /// <summary>
    /// Chromosome arm Q (long arm).
    /// </summary>
    [EnumMember(Value = "Q")]
    [Description("Long arm")]
    Q = 2
}
