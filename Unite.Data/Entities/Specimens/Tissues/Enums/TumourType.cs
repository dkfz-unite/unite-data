using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Tissues.Enums
{
    public enum TumourType
    {
        [EnumMember(Value = "Primary")]
        Primary = 1,

        [EnumMember(Value = "Metastasis")]
        Metastasis = 2,

        [EnumMember(Value = "Recurrent")]
        Recurrent = 3
    }
}
