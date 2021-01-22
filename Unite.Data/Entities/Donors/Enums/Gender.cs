using System.Runtime.Serialization;

namespace Unite.Data.Entities.Donors.Enums
{
    public enum Gender
    {
        /// <summary>
        /// Other
        /// </summary>
        [EnumMember(Value = "Other")]
        Other = 1,

        /// <summary>
        /// Female
        /// </summary>
        [EnumMember(Value = "Female")]
        Female = 2,

        /// <summary>
        /// Male
        /// </summary>
        [EnumMember(Value = "Male")]
        Male = 3
    }
}
