﻿using System.Runtime.Serialization;

namespace Unite.Data.Entities.Mutations.Enums
{
    public enum SampleType
    {
        /// <summary>
        /// Control
        /// </summary>
        [EnumMember(Value = "Control")]
        Control = 1,

        /// <summary>
        /// Tumor
        /// </summary>
        [EnumMember(Value = "Tumor")]
        Tumor = 2
    }
}