using System.Runtime.Serialization;

namespace Unite.Data.Entities.Donors.Enums
{
    public enum AgeCategory
    {
        /// <summary>
        /// Pediatric
        /// </summary>
        [EnumMember(Value = "Pediatric")]
        Pediatric = 1,

        /// <summary>
        /// Adult
        /// </summary>
        [EnumMember(Value = "Adult")]
        Adult = 2
    }
}
