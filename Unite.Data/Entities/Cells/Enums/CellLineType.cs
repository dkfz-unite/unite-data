using System.Runtime.Serialization;

namespace Unite.Data.Entities.Cells.Enums
{
    public enum CellLineType
    {
        /// <summary>
        /// GSC
        /// </summary>
        [EnumMember(Value = "GSC")]
        GSC = 1,

        /// <summary>
        /// Suspension
        /// </summary>
        [EnumMember(Value = "Suspension")]
        Suspension = 2
    }
}
