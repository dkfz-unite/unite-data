using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Unite.Data.Entities.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDefinitionString(this Enum value)
        {
            var type = value.GetType();
            var member = type.GetMember(value.ToString()).FirstOrDefault();
            var attribute = member?.GetCustomAttributes(typeof(EnumMemberAttribute), false).FirstOrDefault() as EnumMemberAttribute;
            var attributeValue = attribute?.Value;
            var objectValue = Convert.ChangeType(value, value.GetTypeCode()).ToString();

            return attributeValue ?? objectValue;
        }
    }
}
