using System.Runtime.Serialization;

namespace Unite.Data.Entities.Genome.Variants.CNV.Enums;


/// <summary>
/// Copy number alteration type (calculated based on TCN and sample ploidy)
/// </summary>
public enum CnvType
{
    /// <summary>
    /// Total number of copies has increased (TCN > ploidy)
    /// </summary>
    [EnumMember(Value = "Gain")]
    Gain = 1,

    /// <summary>
    /// Total number of copies has decreased (TCN < ploidy)
    /// </summary>
    [EnumMember(Value = "Loss")]
    Loss = 2,

    /// <summary>
    /// Total number of copies didn't change (TCN ~ ploidy)
    /// </summary>
    [EnumMember(Value = "Neutral")]
    Neutral = 3
}
