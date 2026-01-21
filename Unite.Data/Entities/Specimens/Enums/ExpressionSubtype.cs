using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Enums;

public enum ExpressionSubtype
{
    /// <summary>
    /// Classical.
    /// </summary>
    [EnumMember(Value = "Classical")]
    Classical = 1,

    /// <summary>
    /// Mesenchymal.
    /// </summary>
    [EnumMember(Value = "Mesenchymal")]
    Mesenchymal = 2,

    /// <summary>
    /// Proneural.
    /// </summary>
    [EnumMember(Value = "Proneural")]
    Proneural = 3
}
