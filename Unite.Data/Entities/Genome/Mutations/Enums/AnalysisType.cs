using System.Runtime.Serialization;

namespace Unite.Data.Entities.Genome.Mutations.Enums;

public enum AnalysisType
{
    [EnumMember(Value = "WGS")]
    WGS = 1,

    [EnumMember(Value = "WES")]
    WES = 2
}
