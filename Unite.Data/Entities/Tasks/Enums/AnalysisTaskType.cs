using System.Runtime.Serialization;

namespace Unite.Data.Entities.Tasks.Enums;

public enum AnalysisTaskType
{
    /// <summary>
    /// Bulk RNA differential expression analysis.
    /// </summary>
    [EnumMember(Value = "RNA-DE")]
    RNA_DE = 1,

    /// <summary>
    /// Single cell RNA dataset creation analysis.
    /// </summary>
    [EnumMember(Value = "RNASC")]
    RNASC = 2
}
