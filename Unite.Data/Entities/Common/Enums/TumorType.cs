using System.Runtime.Serialization;

namespace Unite.Data.Entities.Common.Enums
{
    public enum TumorType
    {
        [EnumMember(Value = "Primary")]
        Primary = 1,

        [EnumMember(Value = "Recurrent")]
        Recurrent = 2
    }
}
