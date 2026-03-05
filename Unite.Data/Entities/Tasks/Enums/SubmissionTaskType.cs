using System.Runtime.Serialization;
using Unite.Data.Constants;

namespace Unite.Data.Entities.Tasks.Enums;

/// <summary>
/// Data submission task type.
/// 1-99: Donor.
/// 100-199: Image.
/// 200-299: Specimen.
/// 300-399: Omics.
/// </summary>
public enum SubmissionTaskType
{

    /// <summary>
    /// Donor general and clinical data.
    /// </summary>
    [EnumMember(Value = DataTypes.Donor.Entry)]
    DON = 0,

    /// <summary>
    /// Donor treatments.
    /// </summary>
    [EnumMember(Value = DataTypes.Donor.Treatment)]
    DON_TRT= 1,

    /// <summary>
    /// MR image metadata.
    /// </summary>
    [EnumMember(Value = DataTypes.Image.Entry.Mr)]
    MR= 100,

    /// <summary>
    /// Image radiomics features.
    /// </summary>
    [EnumMember(Value = DataTypes.Image.Feature)]
    IMG_RAD= 101,

    /// <summary>
    /// Donor derived material general and molecular data.
    /// </summary>
    [EnumMember(Value = DataTypes.Specimen.Entry.Material)]
    MAT= 200,

    /// <summary>
    /// Cell line general and molecular data.
    /// </summary>
    [EnumMember(Value = DataTypes.Specimen.Entry.Line)]
    LNE= 201,

    /// <summary>
    /// Organoid general and molecular data.
    /// </summary>
    [EnumMember(Value = DataTypes.Specimen.Entry.Organoid)]
    ORG= 202,

    /// <summary>
    /// Xenograft general and molecular data.
    /// </summary>
    [EnumMember(Value = DataTypes.Specimen.Entry.Xenograft)]
    XEN= 203,

    /// <summary>
    /// Specimen interventions.
    /// </summary>
    [EnumMember(Value = DataTypes.Specimen.Intervention)]
    SPE_INT= 204,

    /// <summary>
    /// Specimen drugs screening data.
    /// </summary>
    [EnumMember(Value = DataTypes.Specimen.Drug)]
    SPE_DRG= 205,

    /// <summary>
    /// DNA sample.
    /// </summary>
    [EnumMember(Value = DataTypes.Omics.Dna.Sample)]
    DNA = 300,

    /// <summary>
    /// Simple mutations.
    /// </summary>
    [EnumMember(Value = DataTypes.Omics.Dna.Sm)]
    DNA_SM = 301,

    /// <summary>
    /// Copy number variants.
    /// </summary>
    [EnumMember(Value = DataTypes.Omics.Dna.Cnv)]
    DNA_CNV = 302,

    /// <summary>
    /// Copy number variant profiles.
    /// </summary>
    [EnumMember(Value = DataTypes.Omics.Dna.CnvProfile)]
    DNA_CNVP = 304,

    /// <summary>
    /// Structural variants.
    /// </summary>
    [EnumMember(Value = DataTypes.Omics.Dna.Sv)]
    DNA_SV = 303,

    /// <summary>
    /// Methylation sample.
    /// </summary>
    [EnumMember(Value = DataTypes.Omics.Methylation.Sample)]
    METH = 310,

    /// <summary>
    /// Methylation levels.
    /// </summary>
    [EnumMember(Value = DataTypes.Omics.Methylation.Level)]
    METH_LVL = 311,

    /// <summary>
    /// Bulk RNA sample.
    /// </summary>
    [EnumMember(Value = DataTypes.Omics.Rna.Sample)]
    RNA = 320,

    /// <summary>
    /// Bulk gene expressions.
    /// </summary>
    [EnumMember(Value = DataTypes.Omics.Rna.Expression)]
    RNA_EXP = 321,

    /// <summary>
    /// Single cell RNA sample.
    /// </summary>
    [EnumMember(Value = DataTypes.Omics.Rnasc.Sample)]
    RNASC = 330,

    /// <summary>
    /// Single cell gene expressions.
    /// </summary>
    [EnumMember(Value = DataTypes.Omics.Rnasc.Expression)]
    RNASC_EXP = 331,

    /// <summary>
    /// Proteomics sample.
    /// </summary>
    [EnumMember(Value = DataTypes.Omics.Proteomics.Sample)]
    PROT = 340,

    /// <summary>
    /// Protein expressions.
    /// </summary>
    [EnumMember(Value = DataTypes.Omics.Proteomics.Expression)]
    PROT_EXP = 341
}
