using System.Runtime.Serialization;

namespace Unite.Data.Entities.Genome.Variants.CNV.Enums;


/// <summary>
/// Copy number alteration type (calculated based on TCN and sample ploidy)
/// </summary>
public enum CnvType
{
    /// <summary>
    /// Total number of copies is certainly higher than ploidy (TCN > ploidy)
    /// </summary>
    [EnumMember(Value = "Gain")]
    Gain = 1,

    /// <summary>
    /// Total number of copies is certainly lower than ploidy (TCN < ploidy)
    /// </summary>
    [EnumMember(Value = "Loss")]
    Loss = 2,

    /// <summary>
    /// Total number of copies is nearly equal to ploidy  (TCN ~ ploidy)
    /// </summary>
    [EnumMember(Value = "Neutral")]
    Neutral = 3,

    /// <summary>
    /// Not determined
    /// </summary>
    [EnumMember(Value = "Undetermined")]
    Undetermined = 3
}
