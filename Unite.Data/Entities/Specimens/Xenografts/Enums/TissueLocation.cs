using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Xenografts.Enums
{
    public enum TissueLocation
    {
        [EnumMember(Value = "Other")]
        Other = 1,

        [EnumMember(Value = "Striatal")]
        Striatal = 2,

        [EnumMember(Value = "Cortical")]
        Cortical = 3
    }
}
