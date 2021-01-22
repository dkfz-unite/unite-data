using System.Runtime.Serialization;

namespace Unite.Data.Entities.Xenografts.Enums
{
    public enum ImplantType
    {
        /// <summary>
        /// Other
        /// </summary>
        [EnumMember(Value = "Other")]
        Other = 1,

        /// <summary>
        /// Orhtotopical
        /// </summary>
        [EnumMember(Value = "Orhtotopical")]
        Orhtotopical = 2
    }
}
