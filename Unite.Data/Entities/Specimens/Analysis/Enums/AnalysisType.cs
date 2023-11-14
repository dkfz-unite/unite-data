using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Analysis.Enums;

public enum AnalysisType
{
    /// <summary>
    /// Other analysis types
    /// </summary>
    [EnumMember(Value = "Other")]
    Other = 1,

    /// <summary>
    /// Whole Genome Sequencing
    /// </summary>
    [EnumMember(Value = "WGS")]
    WGS = 2,

    /// <summary>
    /// Whole Exome Sequencing
    /// </summary>
    [EnumMember(Value = "WES")]
    WES = 3,

    /// <summary>
    /// Bulk RNA Sequencing
    /// </summary>
    [EnumMember(Value = "RNASeq")]
    RNASeq = 4,

    /// <summary>
    /// Single Cell RNA Sequencing
    /// </summary>
    [EnumMember(Value = "ScRNASeq")]
    ScRNASeq = 5,
}
