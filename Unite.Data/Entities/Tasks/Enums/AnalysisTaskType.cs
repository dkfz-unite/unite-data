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
    /// Differential gene expression (DESeq2).
    /// </summary>
    [EnumMember(Value = "deg")]
    DEG = 1,

    /// <summary>
    /// Genomic alteration frequency.
    /// </summary>
    [EnumMember(Value = "gaf")]
    GAF = 6,

    /// <summary>
    /// scRNA dataset creation.
    /// </summary>
    [EnumMember(Value = "scell")]
    SCELL = 2,

    /// <summary>
    /// Differential protein expression (Limma).
    /// </summary>
    [EnumMember(Value = "dep")]
    DEP = 7
}
