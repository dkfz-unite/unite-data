using System.Runtime.Serialization;

namespace Unite.Data.Entities.Cells.Enums
{
    /// <summary>
    /// IDH
    /// </summary>
    public enum IDHStatus
    {
        /// <summary>
        /// Wild Type
        /// </summary>
        [EnumMember(Value = "WildType")]
        WildType = 1,

        /// <summary>
        /// Mutant
        /// </summary>
        [EnumMember(Value = "Mutant")]
        Mutant = 2
    }
}
