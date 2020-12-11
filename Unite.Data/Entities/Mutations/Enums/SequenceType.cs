using System.Runtime.Serialization;

namespace Unite.Data.Entities.Mutations.Enums
{
    public enum SequenceType
    {
        /// <summary>
        /// c
        /// </summary>
        [EnumMember(Value = "c")]
        CodingDNA = 1,

        /// <summary>
        /// n
        /// </summary>
        [EnumMember(Value = "n")]
        NonCodingDNA = 2,

        /// <summary>
        /// g
        /// </summary>
        [EnumMember(Value = "g")]
        LinearGenomicDNA = 3,

        /// <summary>
        /// o
        /// </summary>
        [EnumMember(Value = "o")]
        CircularGenomicDNA = 4,

        /// <summary>
        /// m
        /// </summary>
        [EnumMember(Value = "m")]
        MitochondrialDNA = 5,

        /// <summary>
        /// r
        /// </summary>
        [EnumMember(Value = "r")]
        RNA = 6,

        /// <summary>
        /// p
        /// </summary>
        [EnumMember(Value = "p")]
        Protein = 7
    }
}
