﻿using System.Runtime.Serialization;

namespace Unite.Data.Entities.Tasks.Enums;

public enum AnnotationTaskType
{
    /// <summary>
    /// Simple somatic mutation
    /// </summary>
    [EnumMember(Value = "SSM")]
    SSM = 1,

    /// <summary>
    /// Copy number variant
    /// </summary>
    [EnumMember(Value = "CNV")]
    CNV = 2,

    /// <summary>
    /// Structural variant
    /// </summary>
    [EnumMember(Value = "SV")]
    SV = 3
}
