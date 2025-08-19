using System.Runtime.Serialization;

namespace Unite.Data.Entities.Tasks.Enums;

/// <summary>
/// Data analysis task type.
/// </summary>
public enum AnalysisTaskType
{
    /// <summary>
    /// Survival curve estimation (Kaplan-Meier).
    /// </summary>
    [EnumMember(Value = "surv")]
    SURV = 3,

    /// <summary>
    /// Differential methylation (Minfi).
    /// </summary>
    [EnumMember(Value = "dm")]
    DM = 4,

    /// <summary>
    /// Principle component analysis for methylation (Minfi).
    /// </summary>
    [EnumMember(Value = "pcam")]
    PCAM = 5,

    /// <summary>
    /// RNA differential expression (DESeq2).
    /// </summary>
    [EnumMember(Value = "de")]
    DE = 1,

    /// <summary>
    /// Genomic alteration frequency.
    /// </summary>
    [EnumMember(Value = "gaf")]
    GAF = 6,

    /// <summary>
    /// scRNA dataset creation.
    /// </summary>
    [EnumMember(Value = "scell")]
    SCELL = 2
}
