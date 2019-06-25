using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace CBV.Core.Domain.Shared
{
    public static class Enumerators
    {

        public class EnumDescription
        {
            public int Key { get; set; }
            public string Value { get; set; }
        }

        public static string GetEnumDescription(System.Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static List<EnumDescription> GetEnumDescriptions(this Type enumType)
        {
            return System.Enum.GetNames(enumType)
                .Select(x => new EnumDescription()
                {
                    Key = (int)System.Enum.Parse(enumType, x),
                    Value = GetEnumDescription((System.Enum)System.Enum.Parse(enumType, x))
                }).ToList();
        }
    }
}
