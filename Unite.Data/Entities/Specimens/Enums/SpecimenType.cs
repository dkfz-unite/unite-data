using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Enums;

public enum SpecimenType
{
    [EnumMember(Value = "Material")]
    Material = 1,

    [EnumMember(Value = "Line")]
    Line = 2,

    [EnumMember(Value = "Organoid")]
    Organoid = 3,

    [EnumMember(Value = "Xenograft")]
    Xenograft = 4
}
