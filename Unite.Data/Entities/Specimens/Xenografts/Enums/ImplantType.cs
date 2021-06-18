using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Xenografts.Enums
{
    public enum ImplantType
    {
        [EnumMember(Value = "Other")]
        Other = 1,

        [EnumMember(Value = "Orhtotopical")]
        Orhtotopical = 2
    }
}
