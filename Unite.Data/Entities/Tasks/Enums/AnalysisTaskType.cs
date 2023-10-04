using System.Runtime.Serialization;

namespace Unite.Data.Entities.Tasks.Enums;

public enum AnalysisTaskType
{
    /// <summary>
    /// Differential Expression
    /// </summary>
    [EnumMember(Value = "DExp")]
    DExp = 1
}
