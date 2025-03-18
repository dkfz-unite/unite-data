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
    /// Donor general and clinical data.
    /// </summary>
    [EnumMember(Value = "don")]
    DON = 0,

    /// <summary>
    /// Donor treatments.
    /// </summary>
    [EnumMember(Value = "don-trt")]
    DON_TRT= 1,

    /// <summary>
    /// MRI image metadata.
    /// </summary>
    [EnumMember(Value = "mri")]
    MRI= 100,

    /// <summary>
    /// Image radiomics features.
    /// </summary>
    [EnumMember(Value = "img-rad")]
    IMG_RAD= 101,

    /// <summary>
    /// Donor derived material general and molecular data.
    /// </summary>
    [EnumMember(Value = "mat")]
    MAT= 200,

    /// <summary>
    /// Cell line general and molecular data.
    /// </summary>
    [EnumMember(Value = "lne")]
    LNE= 201,

    /// <summary>
    /// Organoid general and molecular data.
    /// </summary>
    [EnumMember(Value = "org")]
    ORG= 202,

    /// <summary>
    /// Xenograft general and molecular data.
    /// </summary>
    [EnumMember(Value = "xen")]
    XEN= 203,

    /// <summary>
    /// Specimen interventions.
    /// </summary>
    [EnumMember(Value = "spe-int")]
    SPE_INT= 204,

    /// <summary>
    /// Specimen drugs screening data.
    /// </summary>
    [EnumMember(Value = "spe-drg")]
    SPE_DRG= 205,

    /// <summary>
    /// DNA sample.
    /// </summary>
    [EnumMember(Value = "dna")]
    DNA = 300,

    /// <summary>
    /// Simple somatic mutations.
    /// </summary>
    [EnumMember(Value = "dna-ssm")]
    DNA_SSM = 301,

    /// <summary>
    /// Copy number variants.
    /// </summary>
    [EnumMember(Value = "dna-cnv")]
    DNA_CNV = 302,

    /// <summary>
    /// Structural variants.
    /// </summary>
    [EnumMember(Value = "dna-sv")]
    DNA_SV = 303,

    /// <summary>
    /// Methylation sample.
    /// </summary>
    [EnumMember(Value = "meth")]
    METH = 310,

    /// <summary>
    /// Methylation levels.
    /// </summary>
    [EnumMember(Value = "meth-lvl")]
    METH_LVL = 311,

    /// <summary>
    /// Bulk RNA sample.
    /// </summary>
    [EnumMember(Value = "rna")]
    RNA = 320,

    /// <summary>
    /// Bulk gene expressions.
    /// </summary>
    [EnumMember(Value = "rna-exp")]
    RNA_EXP = 321,

    /// <summary>
    /// Single cell RNA sample.
    /// </summary>
    [EnumMember(Value = "rnasc")]
    RNASC = 330,

    /// <summary>
    /// Single cell gene expressions.
    /// </summary>
    [EnumMember(Value = "rnasc-exp")]
    RNASC_EXP = 331
}
