using System.Runtime.Serialization;

namespace Unite.Data.Entities.Mutations.Enums
{
    public enum AnalysisType
    {
        [EnumMember(Value = "WGS")]
        WGS = 1,

        [EnumMember(Value = "WES")]
        WES = 2,

        [EnumMember(Value = "WGA")]
        WGA = 3,

        [EnumMember(Value = "RNASeq")]
        RNASeq = 4,

        [EnumMember(Value = "Validation")]
        Validation = 5,

        [EnumMember(Value = "Amplicon")]
        Amplicon = 6,
    }
}
