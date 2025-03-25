using System.Runtime.Serialization;

namespace Unite.Data.Entities.Tasks.Enums;

/// <summary>
/// Data analysis task type.
/// </summary> 
public enum AnalysisTaskType
{
    /// <summary>
    /// Bulk RNA differential expression analysis (DESeq2).
    /// </summary>
    [EnumMember(Value = "deseq2")]
    DESEQ2 = 1,

    /// <summary>
    /// Single cell RNA dataset creation analysis.
    /// </summary>
    [EnumMember(Value = "scell")]
    SCELL = 2,

    /// <summary>
    /// Kaplan-Meier survival estimation analysis.
    /// </summary>
    [EnumMember(Value = "kmeier")] 
    KMEIER = 3,

    /// <summary>
    /// Methylation Analysis.
    /// </summary>
    [EnumMember(Value = "meth")]
    METH = 4

}
