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
    /// donors general and clinical data
    /// </summary>
    [EnumMember(Value = "don")]
    DON = 0,

    /// <summary>
    /// donors treatments data
    /// </summary>
    [EnumMember(Value = "don-trt")]
    DON_TRT= 1,

    /// <summary>
    /// MRI images data
    /// </summary>
    [EnumMember(Value = "mri")]
    MRI= 100,

    /// <summary>
    ///  image radiomics features data
    /// </summary>
    [EnumMember(Value = "img-rad")]
    IMG_RAD= 101,

    /// <summary>
    ///  all donor derived materials data
    /// </summary>
    [EnumMember(Value = "mat")]
    MAT= 200,

    /// <summary>
    ///  cell lines data
    /// </summary>
    [EnumMember(Value = "lne")]
    LNE= 201,

    /// <summary>
    ///  organoids data
    /// </summary>
    [EnumMember(Value = "org")]
    ORG= 202,

    /// <summary>
    ///  xenografts data
    /// </summary>
    [EnumMember(Value = "xen")]
    XEN= 203,

    /// <summary>
    ///  specimens interventions data
    /// </summary>
    [EnumMember(Value = "spe-int")]
    SPE_INT= 204,

    /// <summary>
    ///  specimen drugs screening data
    /// </summary>
    [EnumMember(Value = "spe-drg")]
    SPE_DRG= 205,

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
