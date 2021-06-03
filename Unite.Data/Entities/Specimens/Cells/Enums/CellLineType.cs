using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Cells.Enums
{
    public enum CellLineType
    {
        [EnumMember(Value = "GCS")]
        GCS = 1,

        [EnumMember(Value = "Suspension")]
        Suspension = 2
    }
}
