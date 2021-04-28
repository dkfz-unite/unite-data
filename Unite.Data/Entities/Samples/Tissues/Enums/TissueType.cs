using System.Runtime.Serialization;

namespace Unite.Data.Entities.Samples.Tissues.Enums
{
    public enum TissueType
    {
        [EnumMember(Value = "Primary")]
        Primary = 1,

        [EnumMember(Value = "Recurrent")]
        Recurrent = 2
    }
}
