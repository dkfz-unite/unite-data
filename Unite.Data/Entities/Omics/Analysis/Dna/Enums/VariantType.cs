using System.Runtime.Serialization;

namespace Unite.Data.Entities.Omics.Analysis.Dna.Enums;

public enum VariantType
{
    [EnumMember(Value = "SM")]
    SM = 1,

    [EnumMember(Value = "CNV")]
    CNV = 2,

    [EnumMember(Value = "SV")]
    SV = 3
}
