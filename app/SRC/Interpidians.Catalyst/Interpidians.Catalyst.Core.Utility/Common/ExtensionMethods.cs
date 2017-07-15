using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Interpidians.Catalyst.Core.Utility
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Will convert object to XML
        /// </summary>
        /// <param name="oValue"></param>
        /// <returns></returns>
        public static string ToXml(this object oValue)
        {
            XmlSerializer serializer = new XmlSerializer(oValue.GetType());
            using (StringWriter stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, oValue);
                return StripXmlNamespaces(stringWriter.ToString());
            }
        }

        public static string StripXmlNamespaces(string xml)
        {
            string strXMLPattern = @"xmlns(:\w+)?=""([^""]+)""|xsi(:\w+)?=""([^""]+)""";
            xml = Regex.Replace(xml, strXMLPattern, "");
            return xml;
        }

        /// <summary>
        /// Returns hour,minute or second from time string
        /// </summary>
        /// <param name="strTimeSpan"></param>
        /// <param name="strTimePart"></param>
        /// <returns></returns>
        public static int SplitTimePart(this string strTimeSpan,string strTimePart)
        {
            string[] strAllTimeParts=strTimeSpan.Split(new char[] {':'},StringSplitOptions.RemoveEmptyEntries);
            int timePart;

            switch (strTimePart)
            {
                case "H":
                    timePart = Convert.ToInt16(strAllTimeParts[0]);
                    break;
                case "M":
                    timePart = Convert.ToInt16(strAllTimeParts[1]);
                    break;
                case "S":
                    timePart = Convert.ToInt16(strAllTimeParts[2]);
                    break;
                default:
                    timePart = 0;
                    break;
            }

            return timePart;
            
        }

        /// <summary>
        /// Will convert list into datatable through reflection
        /// </summary>
        /// <typeparam name="T">Type of list</typeparam>
        /// <param name="iList">Current list</param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this List<T> iList)
        {
            DataTable dataTable = new DataTable();

            //Add columns

            PropertyDescriptorCollection propertyDescriptorCollection =
                TypeDescriptor.GetProperties(typeof(T));

            for (int i = 0; i < propertyDescriptorCollection.Count; i++)
            {
                PropertyDescriptor propertyDescriptor = propertyDescriptorCollection[i];
                Type type = propertyDescriptor.PropertyType;

                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    type = Nullable.GetUnderlyingType(type);


                dataTable.Columns.Add(propertyDescriptor.Name, type);
            }

            //Add values to columns
            object[] values = new object[propertyDescriptorCollection.Count];

            foreach (T iListItem in iList)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = propertyDescriptorCollection[i].GetValue(iListItem);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
