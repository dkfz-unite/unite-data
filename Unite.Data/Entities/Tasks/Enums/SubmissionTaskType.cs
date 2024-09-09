using System.Runtime.Serialization;

namespace Unite.Data.Entities.Tasks.Enums;

/// <summary>
/// Data submission task type.
/// 0-99: Donor.
/// 100-199: Image.
/// 200-299: Specimen.
/// 300-399: Genome.
/// </summary>
public enum SubmissionTaskType
{
    /// <summary>
    /// Simple somatic mutation
    /// </summary>
    [EnumMember(Value = "dna-ssm")]
    DNA_SSM = 301,

    /// <summary>
    /// Copy number variant
    /// </summary>
    [EnumMember(Value = "dna-cnv")]
    DNA_CNV = 302,

    /// <summary>
    /// Structural variant
    /// </summary>
    [EnumMember(Value = "dna-sv")]
    DNA_SV = 303,

    /// <summary>
    /// Bulk gene expression
    /// </summary>
    [EnumMember(Value = "rna-exp")]
    RNA_EXP = 321,

    /// <summary>
    /// Single cell gene expression
    /// </summary>
    [EnumMember(Value = "rnasc-exp")]
    RNASC_EXP = 341
}
