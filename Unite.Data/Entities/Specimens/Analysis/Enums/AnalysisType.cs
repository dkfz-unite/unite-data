using System.ComponentModel;
using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Analysis.Enums;

public enum AnalysisType
{
    /// <summary>
    /// Drugs screening analysis.
    /// </summary>
    [EnumMember(Value = "DSA")]
    [Description("Drugs Screening Analysis")]
    DSA = 1
}
