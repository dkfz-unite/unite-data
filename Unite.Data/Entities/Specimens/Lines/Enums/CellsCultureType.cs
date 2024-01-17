using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Lines.Enums;

public enum CellsCultureType
{
    [EnumMember(Value = "Suspension")]
    Suspension = 1,

    [EnumMember(Value = "Adherent")]
    Adherent = 2,

    [EnumMember(Value = "Both")]
    Both = 3,
}
