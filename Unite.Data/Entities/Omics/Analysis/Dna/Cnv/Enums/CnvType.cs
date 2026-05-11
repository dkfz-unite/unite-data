using System.ComponentModel;
using System.Runtime.Serialization;

namespace Unite.Data.Entities.Omics.Analysis.Dna.Cnv.Enums;


/// <summary>
/// Copy number alteration type (calculated based on TCN and sample ploidy).
/// </summary>
public enum CnvType
{
    /// <summary>
    /// Total number of copies is certainly higher than ploidy (TCN > ploidy).
    /// </summary>
    [EnumMember(Value = "Gain")]
    [Description("TCN gain")]
    Gain = 1,

    /// <summary>
    /// Total number of copies is certainly lower than ploidy (TCN < ploidy).
    /// </summary>
    [EnumMember(Value = "Loss")]
    [Description("TCN loss")]
    Loss = 2,

    /// <summary>
    /// Total number of copies is nearly equal to ploidy  (TCN ~ ploidy).
    /// </summary>
    [EnumMember(Value = "Neutral")]
    [Description("TCN neutral")]
    Neutral = 3,

    /// <summary>
    /// Not determined.
    /// </summary>
    [EnumMember(Value = "Undetermined")]
    [Description("Undetermined")]
    Undetermined = 4
}
