using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace Interpidians.Catalyst.Core.Utility
{
    /// <summary>
    /// Data Table Extension class.
    /// </summary>
    public static class DataTableExtensions
    {
        /// <summary>
        /// Type Dictionary
        /// </summary>
        private static Dictionary<Type, List<PropertyInfo>> typeDictionary = new Dictionary<Type, List<PropertyInfo>>();

        /// <summary>
        /// Gets the type of the properties for.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<PropertyInfo> GetPropertiesForType<T>()
        {
            var type = typeof(T);
            if (!typeDictionary.ContainsKey(typeof(T)))
            {
                typeDictionary.Add(type, type.GetProperties().ToList());
            }
            return typeDictionary[type];
        }

        /// <summary>
        /// Converts To list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dTable">The D table.</param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable dTable) where T : new()
        {
            List<PropertyInfo> properties = GetPropertiesForType<T>();
            List<T> result = new List<T>();

            foreach (var row in dTable.Rows)
            {
                var item = CreateItemFromRow<T>((DataRow)row, properties, dTable);
                result.Add(item);
            }

            return result;
        }

        /// <summary>
        /// Creates the item from row.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row">The row.</param>
        /// <param name="properties">The properties.</param>
        /// <param name="DTable">The Data table.</param>
        /// <returns></returns>
        private static T CreateItemFromRow<T>(DataRow row, List<PropertyInfo> properties, DataTable DTable) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                if (DTable.Columns.Contains(property.Name))
                {
                    if (Nullable.GetUnderlyingType(property.PropertyType) != null)
                    {
                        if (row[property.Name] == DBNull.Value)
                        {
                            property.SetValue(item, null, null);
                        }
                        else
                        {
                            property.SetValue(item, Convert.ChangeType(row[property.Name], Type.GetType(Nullable.GetUnderlyingType(property.PropertyType).ToString())), null);
                        }
                    }
                    else
                    {
                        if (row[property.Name] == DBNull.Value)
                        {
                            property.SetValue(item, null, null);
                        }
                        else
                        {
                            property.SetValue(item, Convert.ChangeType(row[property.Name], Type.GetType(property.PropertyType.ToString())), null);
                        }
                    }
                }
            }
            return item;
        }
    }
}
