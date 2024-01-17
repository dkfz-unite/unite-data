using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Lines.Enums;

public enum CellsSpecies
{
    [EnumMember(Value = "Human")]
    Human = 1,

    [EnumMember(Value = "Mouse")]
    Mouse = 2
}
