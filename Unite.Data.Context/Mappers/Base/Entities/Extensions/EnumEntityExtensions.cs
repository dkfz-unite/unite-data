using System.ComponentModel;
using Unite.Essentials.Extensions;

namespace Unite.Data.Context.Mappers.Base.Entities.Extensions;

internal static class EnumEntityExtensions
{
    public static EnumEntity<T> ToEnumValue<T>(this T id, string value = null, string name = null) where T : Enum
    {
        if (name == null)
        {
            var type = typeof(T);
            var member = type.GetMember(id.ToString()).First();
            
            var description = member
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .Cast<DescriptionAttribute>()
                .FirstOrDefault();
            
            if(description != null)
                name = description.Description;
        }
        
        return new EnumEntity<T>()
        {
            Id = id,
            Value = value ?? id.ToDefinitionString(),
            Name = name ?? id.ToDefinitionString()
        };
    }
}
