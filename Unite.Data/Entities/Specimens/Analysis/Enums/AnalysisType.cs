using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Analysis.Enums;

public enum AnalysisType
{
    /// <summary>
    /// Drugs screening analysis
    /// </summary>
    [EnumMember(Value = "DSA")]
    DSA = 1
}
