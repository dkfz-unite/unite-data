using System.Runtime.Serialization;

namespace Unite.Data.Entities.Donors.Enums
{
    public enum Gender
    {
        /// <summary>
        /// Female
        /// </summary>
        [EnumMember(Value = "Female")]
        Female = 1,

        /// <summary>
        /// Male
        /// </summary>
        [EnumMember(Value = "Male")]
        Male = 2,

        /// <summary>
        /// Other
        /// </summary>
        [EnumMember(Value = "Other")]
        Other = 3
    }
}
