using System.Runtime.Serialization;

namespace Unite.Data.Entities.Tasks.Enums;

public enum IndexingTaskType
{
    /// <summary>
    /// Project.
    /// </summary>
    [EnumMember(Value = "Project")]
    Project = 1,

    /// <summary>
    /// Donor.
    /// </summary>
    [EnumMember(Value = "Donor")]
    Donor = 2,

    /// <summary>
    /// Image.
    /// </summary>
    [EnumMember(Value = "Image")]
    Image = 3,

    /// <summary>
    /// Specimen.
    /// </summary>
    [EnumMember(Value = "Specimen")]
    Specimen = 4,

    /// <summary>
    /// Gene.
    /// </summary>
    [EnumMember(Value = "Gene")]
    Gene = 5,

    /// <summary>
    /// SM.
    /// </summary>
    [EnumMember(Value = "SM")]
    SM = 6,

    /// <summary>
    /// CNV.
    /// </summary>
    [EnumMember(Value = "CNV")]
    CNV = 7,

    /// <summary>
    /// SV.
    /// </summary>
    [EnumMember(Value = "SV")]
    SV = 8
}
