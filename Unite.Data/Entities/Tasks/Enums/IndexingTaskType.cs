using System.Runtime.Serialization;

namespace Unite.Data.Entities.Tasks.Enums;

public enum IndexingTaskType
{
    /// <summary>
    /// Donor
    /// </summary>
    [EnumMember(Value = "Donor")]
    Donor = 1,

    /// <summary>
    /// Image
    /// </summary>
    [EnumMember(Value = "Image")]
    Image = 2,

    /// <summary>
    /// Specimen
    /// </summary>
    [EnumMember(Value = "Specimen")]
    Specimen = 3,

    /// <summary>
    /// Gene
    /// </summary>
    [EnumMember(Value = "Gene")]
    Gene = 4,

    /// <summary>
    /// SSM
    /// </summary>
    [EnumMember(Value = "SSM")]
    SSM = 5,

    /// <summary>
    /// CNV
    /// </summary>
    [EnumMember(Value = "CNV")]
    CNV = 6,

    /// <summary>
    /// SV
    /// </summary>
    [EnumMember(Value = "SV")]
    SV = 7
}
