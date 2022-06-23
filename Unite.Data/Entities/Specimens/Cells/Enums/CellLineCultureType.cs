using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Cells.Enums;

public enum CellLineCultureType
{
    [EnumMember(Value = "Suspension")]
    Suspension = 1,

    [EnumMember(Value = "Adherent")]
    Adherent = 2,

    [EnumMember(Value = "Both")]
    Both = 3,
}
