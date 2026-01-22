using System.Runtime.Serialization;

namespace Unite.Data.Entities.Omics.Enums;

public enum ChromosomeArm
{
    /// <summary>
    /// Chromosome 1.
    /// </summary>
    [EnumMember(Value = "Short")]
    Short,
    [EnumMember(Value = "Long")]
    Long
}