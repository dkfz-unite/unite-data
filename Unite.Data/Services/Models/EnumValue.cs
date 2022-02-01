using System;
using Unite.Data.Extensions;

namespace Unite.Data.Services.Models
{
    internal class EnumValue<T> where T : Enum
    {
        public T Id { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
    }

    internal static class EnumExtensions
    {
        public static EnumValue<T> ToEnumValue<T>(this T id, string value = null, string name = null) where T : Enum
        {
            return new EnumValue<T>()
            {
                Id = id,
                Value = value ?? id.ToDefinitionString(),
                Name = name ?? id.ToDefinitionString()
            };
        }
    }
}
