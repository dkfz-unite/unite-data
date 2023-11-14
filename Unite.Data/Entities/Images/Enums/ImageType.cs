using System.Runtime.Serialization;

namespace Unite.Data.Entities.Images.Enums;

public enum ImageType
{
    [EnumMember(Value = "MRI")]
    Mri = 1,

    [EnumMember(Value = "CT")]
    Ct = 2
}
