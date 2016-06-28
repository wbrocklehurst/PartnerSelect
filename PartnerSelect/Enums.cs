using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace PartnerSelect
{
    public class Enums
    {
        /// <summary>
        /// Return string description from enum.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string StringValueOf(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        /// <summary>
        /// Return value of string from enum type.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static object EnumValueOf(string value, Type enumType)
        {
            var names = Enum.GetNames(enumType);
            foreach (var name in names.Where(name => StringValueOf((Enum)Enum.Parse(enumType, name)).Equals(value)))
            {
                return Enum.Parse(enumType, name);
            }

            throw new ArgumentException("The string is not a description or value of the specified enum.");
        }
    }
}