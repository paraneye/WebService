using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace Element.Shared.Common
{
    /// <summary>
    /// Enumerator Attirbute Call
    /// </summary>
    public class EnumHelper
    {
        public EnumHelper()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string toDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        public static object toValueOf(string value, Type enumType)
        {
            string[] names = Enum.GetNames(enumType);
            foreach (string name in names)
            {
                if (toDescription((Enum)Enum.Parse(enumType, name)).Equals(value))
                {
                    return Enum.Parse(enumType, name);
                }
            }

            throw new ArgumentException("The string is not a description or value of the specified enum.");
        }
    }


    /// <summary>
    /// Upload File Extension check regex
    /// </summary>
    public enum UploadType
    {
        [DescriptionAttribute("")]
        All,

        [DescriptionAttribute(@"([^\s]+(\.(?i)(mp2|mp3|m3u))$)")]
        Audio,

        [DescriptionAttribute(@"([^\s]+(\.(?i)(avi|mpg|mpeg))$)")]
        Video,

        [DescriptionAttribute(@"([^\s]+(\.(?i)(doc|docx|txt))$)")]
        Document,

        [DescriptionAttribute(@"([^\s]+(\.(?i)(jpg|png|gif|bmp))$)")]
        Image
    }

}
