using System.Runtime.Serialization;

namespace Unite.Data.Entities.Donors.Enums
{
    public enum VitalStatus
    {
        /// <summary>
        /// Living
        /// </summary>
        [EnumMember(Value = "Living")]
        Living = 1,

        /// <summary>
        /// Deceased
        /// </summary>
        [EnumMember(Value = "Deceased")]
        Deceased = 2
    }
}
