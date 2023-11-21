using System.Runtime.Serialization;

namespace Unite.Data.Entities.Genome.Analysis.Enums;

public enum AnalysisType
{
    [EnumMember(Value = "Other")]
    Other = 1,

    [EnumMember(Value = "WGS")]
    WGS = 2,

    [EnumMember(Value = "WES")]
    WES = 3,

    [EnumMember(Value = "RNASeq")]
    RNASeq = 4,

    [EnumMember(Value = "ScRNASeq")]
    ScRNASeq = 5
}
