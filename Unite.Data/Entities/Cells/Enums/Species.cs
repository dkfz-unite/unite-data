using System.Runtime.Serialization;

namespace Unite.Data.Entities.Cells.Enums
{
    public enum Species
    {
        /// <summary>
        /// Human
        /// </summary>
        [EnumMember(Value = "Human")]
        Human = 1,

        /// <summary>
        /// Mouse
        /// </summary>
        [EnumMember(Value = "Mouse")]
        Mouse = 2
    }
}
