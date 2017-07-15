using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Interpidians.Catalyst.Core.Utility
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets a String representing the DefaultValueAttribute of the Enum Type.
        /// </summary>
        public static string GetDefaultValue(this Enum enumType)
        {
            // Get the type
            Type type = enumType.GetType();

            // Get fieldinfo for this type 
            FieldInfo fieldInfo = type.GetField(enumType.ToString());

            // Get the stringvalue attributes 
            DefaultValueAttribute[] attribs = fieldInfo.GetCustomAttributes(typeof(DefaultValueAttribute), false) as DefaultValueAttribute[];

            // Return the first if there was a match. 
            return attribs.Length > 0 ? Convert.ToString(attribs[0].Value) : null;
        }

        /// <summary>
        /// Gets a String representing the DescriptionAttribute of the Enum Type.
        /// </summary>
        public static string GetDescription(this Enum enumType)
        {
            // Get the type 
            Type type = enumType.GetType();

            // Get fieldinfo for this type 
            FieldInfo fieldInfo = type.GetField(enumType.ToString());

            // Get the stringvalue attributes 
            DescriptionAttribute[] attribs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            // Return the first if there was a match. 
            return attribs.Length > 0 ? attribs[0].Description : null;
        }
    }
}
