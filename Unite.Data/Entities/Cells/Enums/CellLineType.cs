using System.Runtime.Serialization;

namespace Unite.Data.Entities.Cells.Enums
{
    public enum CellLineType
    {
        [EnumMember(Value = "GSC")]
        GCS = 1,

        [EnumMember(Value = "Suspension")]
        Suspension = 2
    }
}
