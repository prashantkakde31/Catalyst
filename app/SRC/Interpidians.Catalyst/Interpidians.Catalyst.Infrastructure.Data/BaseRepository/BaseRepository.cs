using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Interpidians.Catalyst.Infrastructure.Data
{
    public class BaseRepository
    {
        private Database _db = null;

        protected Database DB
        {
            get
            {
                return _db;
            }
        }

        public BaseRepository()
        {
            _db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

        }

        /// <summary>
        /// Used to map dataTable to domain model list
        /// </summary>
        /// <typeparam name="T">model to map</typeparam>
        /// <param name="dr">data read from database</param>
        /// <param name="lstmodel">model list to map</param>
        protected void MapListRecord<T>(IDataReader dr, IList<T> lstmodel) where T : new()
        {
            DataTable dt = dr.GetSchemaTable();
            while (dr.Read())
            {
                T t = new T();
                foreach (DataRow row in dt.Select())
                {
                    if (!string.IsNullOrEmpty(dr[row["ColumnName"].ToString()].ToString()))
                    {
                        t.GetType().GetProperty(row["ColumnName"].ToString()).SetValue(t, dr[row["ColumnName"].ToString()], null);
                    }
                }
                lstmodel.Add(t);
            }

        }

        /// <summary>
        /// Used to map dataTable to single domain model
        /// </summary>
        /// <typeparam name="T">model to map</typeparam>
        /// <param name="dr">data read from database</param>
        /// <param name="model">model to map</param>
        protected void MapRecord<T>(IDataReader dr, T model) where T : new()
        {
            DataTable dt = dr.GetSchemaTable();
            if (dr.Read())
            {

                foreach (DataRow row in dt.Select())
                {
                    if (!string.IsNullOrEmpty(dr[row["ColumnName"].ToString()].ToString()))
                    {
                        model.GetType().GetProperty(row["ColumnName"].ToString()).SetValue(model, dr[row["ColumnName"].ToString()], null);
                    }
                }

            }

        }

        /// <summary>
        /// Used to check whether DB procedure exists or not
        /// </summary>
        /// <param name="paramsDictionary"></param>
        /// <returns></returns>
        public bool IsExists(Dictionary<string, string> paramsDictionary)
        {
            DbCommand isexistsCommnad = this.DB.GetStoredProcCommand(Convert.ToString(paramsDictionary["SPName"]));

            foreach (KeyValuePair<string, string> kvp in paramsDictionary)
            {
                if (kvp.Key.ToLower() != "spname")
                {
                    this.DB.AddInParameter(isexistsCommnad, kvp.Key, System.Data.DbType.String, kvp.Value);
                }
            }
            bool result = (bool)this.DB.ExecuteScalar(isexistsCommnad);
            return result;

        }

    }
}
