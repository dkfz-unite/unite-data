using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Cells.Enums
{
    public enum CellLineType
    {
        [EnumMember(Value = "Stem Cell")]
        StemCell = 1,

        [EnumMember(Value = "Differentiated")]
        Differentiated = 2
    }
}
