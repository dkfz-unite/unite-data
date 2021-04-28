using System.Runtime.Serialization;

namespace Unite.Data.Entities.Molecular.Enums
{
    /// <summary>
    /// IDH
    /// </summary>
    public enum IDHStatus
    {
        /// <summary>
        /// Wild Type
        /// </summary>
        [EnumMember(Value = "Wild Type")]
        WildType = 1,

        /// <summary>
        /// Mutant
        /// </summary>
        [EnumMember(Value = "Mutant")]
        Mutant = 2
    }
}
