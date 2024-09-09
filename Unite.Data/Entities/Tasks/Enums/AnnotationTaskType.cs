using System.Runtime.Serialization;

namespace Unite.Data.Entities.Tasks.Enums;

/// <summary>
/// Data annotation task type.
/// 0-99: Donor.
/// 100-199: Image.
/// 200-299: Specimen.
/// 300-399: Genome.
/// </summary> 
public enum AnnotationTaskType
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
    DNA_SV = 303
}
