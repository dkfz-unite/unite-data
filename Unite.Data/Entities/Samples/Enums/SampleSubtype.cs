using System.Runtime.Serialization;

namespace Unite.Data.Entities.Samples.Enums
{
    public enum SampleSubtype
    {
        /// <summary>
        /// Primary
        /// </summary>
        [EnumMember(Value = "Primary")]
        Primary = 1,

        /// <summary>
        /// Recurrent
        /// </summary>
        [EnumMember(Value = "Recurrent")]
        Recurrent = 2
    }
}
