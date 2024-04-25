using System.Runtime.Serialization;

namespace Unite.Data.Entities.Tasks.Enums;

public enum SubmissionTaskType
{
    /// <summary>
    /// Simple somatic mutation
    /// </summary>
    [EnumMember(Value = "SSM")]
    SSM = 1,

    /// <summary>
    /// Copy number variant
    /// </summary>
    [EnumMember(Value = "CNV")]
    CNV = 2,

    /// <summary>
    /// Structural variant
    /// </summary>
    [EnumMember(Value = "SV")]
    SV = 3,

    /// <summary>
    /// Bulk gene expression
    /// </summary>
    [EnumMember(Value = "BGE")]
    BGE = 4,

    /// <summary>
    /// Single cell gene expression
    /// </summary>
    [EnumMember(Value = "CGE")]
    CGE = 5
}
