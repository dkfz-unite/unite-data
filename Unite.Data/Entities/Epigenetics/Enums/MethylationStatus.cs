using System.Runtime.Serialization;

namespace Unite.Data.Entities.Epigenetics.Enums
{
    /// <summary>
    /// MGMT
    /// </summary>
    public enum MethylationStatus
    {
        /// <summary>
        /// Unmethylated
        /// </summary>
        [EnumMember(Value = "Unmethylated")]
        Unmethylated = 1,

        /// <summary>
        /// Methylated
        /// </summary>
        [EnumMember(Value = "Methylated")]
        Methylated = 2,
    }
}
