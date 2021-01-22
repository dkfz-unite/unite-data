using System.Runtime.Serialization;

namespace Unite.Data.Entities.Xenografts.Enums
{
    public enum GrowthForm
    {
        /// <summary>
        /// Bulk
        /// </summary>
        [EnumMember(Value = "Bulk")]
        Bulk = 1,

        /// <summary>
        /// Weak
        /// </summary>
        [EnumMember(Value = "Weak")]
        Weak = 2,

        /// <summary>
        /// Medium
        /// </summary>
        [EnumMember(Value = "Medium")]
        Medium = 3,

        /// <summary>
        /// Strong
        /// </summary>
        [EnumMember(Value = "Strong")]
        Strong = 4
    }
}
