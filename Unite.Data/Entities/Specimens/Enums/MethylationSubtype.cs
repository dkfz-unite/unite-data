using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Enums;

public enum MethylationSubtype
{
    /// <summary>
    /// H3-K27.
    /// </summary>
    [EnumMember(Value = "H3-K27")]
    H3_K27 = 1,

    /// <summary>
    /// H3-G34.
    /// </summary>
    [EnumMember(Value = "H3-G34")]
    H3_G34 = 2,

    /// <summary>
    /// RTKI.
    /// </summary>
    [EnumMember(Value = "RTKI")]
    RTKI = 3,

    /// <summary>
    /// RTKII.
    /// </summary>
    [EnumMember(Value = "RTKII")]
    RTKII = 4,

    /// <summary>
    /// Mesenchymal.
    /// </summary>
    [EnumMember(Value = "Mesenchymal")]
    Mesenchymal = 5
}
