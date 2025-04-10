using Unite.Essentials.Extensions;

namespace Unite.Data.Context.Mappers.Base.Entities.Extensions;

internal static class EnumEntityExtensions
{
    public static EnumEntity<T> ToEnumValue<T>(this T id, string value = null, string name = null) where T : Enum
    {
        return new EnumEntity<T>()
        {
            Id = id,
            Value = value ?? id.ToDefinitionString(),
            Name = name ?? id.ToDefinitionString()
        };
    }
}
