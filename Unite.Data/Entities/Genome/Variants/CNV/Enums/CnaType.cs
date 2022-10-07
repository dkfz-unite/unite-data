using System.Runtime.Serialization;

namespace Unite.Data.Entities.Genome.Variants.CNV.Enums;


/// <summary>
/// Copy number alteration type
/// </summary>
public enum CnaType
{
    /// <summary>
    /// Total number of copies has increased
    /// </summary>
    [EnumMember(Value = "Gain")]
    Gain = 1,

    /// <summary>
    /// Total number of copies has decreased
    /// </summary>
    [EnumMember(Value = "Loss")]
    Loss = 2,

    /// <summary>
    /// Total number of copies didn't change
    /// </summary>
    [EnumMember(Value = "Neutral")]
    Neutral = 3
}
