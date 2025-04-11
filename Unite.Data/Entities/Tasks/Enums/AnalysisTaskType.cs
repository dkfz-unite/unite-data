using System.Runtime.Serialization;

namespace Unite.Data.Entities.Tasks.Enums;

/// <summary>
/// Data analysis task type.
/// 1-99: Donor.
/// 100-199: Image.
/// 200-299: Specimen.
/// 300-399: Genome.
/// 400+: Cross-type.
/// </summary>
public enum AnalysisTaskType
{
    /// <summary>
    /// Survival curve estimation (Kaplan-Meier).
    /// </summary>
    [EnumMember(Value = "don-sce")] 
    DON_SCE = 1,

    /// <summary>
    /// Differential methylation (Minfi).
    /// </summary>
    [EnumMember(Value = "meth-dm")]
    METH_DM = 300,

    /// <summary>
    /// RNA differential expression (DESeq2).
    /// </summary>
    [EnumMember(Value = "rna_de")]
    RNA_DE = 301,

    /// <summary>
    /// scRNA dataset creation.
    /// </summary>
    [EnumMember(Value = "rnasc_dc")]
    RNASC_DC = 302
}
