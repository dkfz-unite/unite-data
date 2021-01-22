using System.Runtime.Serialization;

namespace Unite.Data.Entities.Xenografts.Enums
{
    public enum TumorSize
    {
        /// <summary>
        /// No
        /// </summary>
        [EnumMember(Value = "No")]
        No = 1,

        /// <summary>
        /// Small
        /// </summary>
        [EnumMember(Value = "Small")]
        Small = 2,

        /// <summary>
        /// Medium
        /// </summary>
        [EnumMember(Value = "Medium")]
        Medium = 3,

        /// <summary>
        /// Large
        /// </summary>
        [EnumMember(Value = "Large")]
        Large = 4
    }
}
