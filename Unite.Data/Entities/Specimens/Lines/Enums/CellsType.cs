using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Lines.Enums;

public enum CellsType
{
    [EnumMember(Value = "Stem Cell")]
    StemCell = 1,

    [EnumMember(Value = "Differentiated")]
    Differentiated = 2
}
