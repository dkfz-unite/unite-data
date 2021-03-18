using System.Runtime.Serialization;

namespace Unite.Data.Entities.Tasks.Enums
{
    public enum TaskTargetType
    {
        [EnumMember(Value = "Donor")]
        Donor = 1,

        [EnumMember(Value = "Mutation")]
        Mutation = 2,

        [EnumMember(Value = "Gene")]
        Gene = 3,

        [EnumMember(Value = "CellLine")]
        CellLine = 4,

        [EnumMember(Value = "Xenograft")]
        Xenograft = 5,

        [EnumMember(Value = "MRIFeature")]
        MRIFeature = 6
    }
}
