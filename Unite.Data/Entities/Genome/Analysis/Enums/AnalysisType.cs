using System.Runtime.Serialization;

namespace Unite.Data.Entities.Genome.Analysis.Enums;

public enum AnalysisType
{
    [EnumMember(Value = "WGS")]
    WGS = 1,

    [EnumMember(Value = "WES")]
    WES = 2,

    [EnumMember(Value = "RNASeq")]
    RNASeq = 3,

    [EnumMember(Value = "RNASeqSc")]
    RNASeqSc = 4
}
