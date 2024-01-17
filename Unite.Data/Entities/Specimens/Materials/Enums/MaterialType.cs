using System.Runtime.Serialization;

namespace Unite.Data.Entities.Specimens.Materials.Enums;

public enum MaterialType
{
    [EnumMember(Value = "Normal")]
    Normal = 1,

    [EnumMember(Value = "Tumor")]
    Tumor = 2
}
