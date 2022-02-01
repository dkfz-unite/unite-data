using System.Runtime.Serialization;

namespace Unite.Data.Entities.Genome.Mutations.Enums
{
    public enum ConsequenceImpact
    {
        /// <summary>
        /// High
        /// </summary>
        [EnumMember(Value = "High")]
        High = 1,

        /// <summary>
        /// Moderate
        /// </summary>
        [EnumMember(Value = "Moderate")]
        Moderate = 2,

        /// <summary>
        /// Low
        /// </summary>
        [EnumMember(Value = "Low")]
        Low = 3,

        /// <summary>
        /// Unknown
        /// </summary>
        [EnumMember(Value = "Unknown")]
        Unknown = 4
    }
}
