using System.Runtime.Serialization;

namespace Unite.Data.Entities.Xenografts.Enums
{
    public enum TissueLocation
    {
        /// <summary>
        /// Intracranial
        /// </summary>
        [EnumMember(Value = "Intracranial")]
        Intracranial = 1,

        /// <summary>
        /// Striatal
        /// </summary>
        [EnumMember(Value = "Striatal")]
        Striatal = 2,

        /// <summary>
        /// Cortical
        /// </summary>
        [EnumMember(Value = "Cortical")]
        Cortical = 3
    }
}
