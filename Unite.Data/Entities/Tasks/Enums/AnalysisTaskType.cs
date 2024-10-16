using System.Runtime.Serialization;

namespace Unite.Data.Entities.Tasks.Enums;

/// <summary>
/// Data analysis task type.
/// 0-99: Donor.
/// 100-199: Image.
/// 200-299: Specimen.
/// 300-399: Genome.
/// </summary> 
public enum AnalysisTaskType
{
    /// <summary>
    /// Donors Kaplan-Meier survival estimation analysis.
    /// </summary>
    DON_KM = 0,

    /// <summary>
    /// Bulk RNA differential expression analysis.
    /// </summary>
    [EnumMember(Value = "rna-de")]
    RNA_DE = 320,

    /// <summary>
    /// Single cell RNA dataset creation analysis.
    /// </summary>
    [EnumMember(Value = "rnacs")]
    RNASC = 340
}
