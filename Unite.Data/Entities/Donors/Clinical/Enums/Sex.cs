using System.Runtime.Serialization;

namespace Unite.Data.Entities.Donors.Clinical.Enums;

public enum Sex
{
    /// <summary>
    /// Other.
    /// </summary>
    [EnumMember(Value = "Other")]
    Other = 1,

    /// <summary>
    /// Female.
    /// </summary>
    [EnumMember(Value = "Female")]
    Female = 2,

    /// <summary>
    /// Male.
    /// </summary>
    [EnumMember(Value = "Male")]
    Male = 3
}
