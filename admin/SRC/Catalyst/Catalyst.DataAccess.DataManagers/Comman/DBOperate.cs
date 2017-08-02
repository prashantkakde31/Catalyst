namespace Catalyst.DataAccess.DataManagers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Configuration;

    /// <summary>
    /// Common Methods to support database functionalities
    /// </summary>
    public sealed class DBOperate
    {
        /// <summary>
        /// The connection string
        /// </summary>
        //private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["conStr"].ToString();
        //private static string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Diet;Integrated Security=True";
        //private static string connectionString = "Data Source=SUBHASH;Initial Catalog=Diet;Integrated Security=True";
        //private static string connectionString = "Data Source=localhost;Initial Catalog=Diet;Integrated Security=True";
        private static string connectionString = ConfigurationManager.ConnectionStrings["connDietDB"].ToString();

        /// <summary>
        /// Prevents a default instance of the <see cref="DBOperate"/> class from being created.
        /// </summary>
        private DBOperate()
        {
        }

        /// <summary>
        /// Retrieve data table from database
        /// </summary>
        /// <param name="commandText">Command Text</param>
        /// <param name="parameters">Database Parameters</param>
        /// <returns>Returns data table</returns>
        public static DataTable GetDataTable(string commandText, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    DataSet tableDetails = new DataSet();
                    sqlCon.Open();

                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandText = commandText;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Connection = sqlCon;
                    if (parameters != null)
                    {
                        foreach (SqlParameter sparam in parameters)
                        {
                            sqlCmd.Parameters.Add(sparam);
                        }
                    }

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd);
                    sqlAdapter.Fill(tableDetails);
                    return tableDetails.Tables[0];
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieve data table from database 
        /// </summary>
        /// <param name="query">query</param>        
        /// <returns>Returns data table</returns>
        public static DataTable GetDataTable(string procedureName)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    DataSet tableDetails = new DataSet();
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(procedureName);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Connection = sqlCon;
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd);
                    sqlAdapter.Fill(tableDetails);
                    return tableDetails.Tables[0];
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieve data set from database 
        /// </summary>
        /// <param name="query">query</param>        
        /// <returns>Returns data set</returns>
        public static DataSet GetDataSet(string procedureName)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    DataSet tableDetails = new DataSet();
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand(procedureName);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Connection = sqlCon;
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd);
                    sqlAdapter.Fill(tableDetails);
                    return tableDetails;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieve data set from database 
        /// </summary>
        /// <param name="query">query</param> 
        /// <param name="parameters">Database Parameters</param>
        /// <returns>Returns data set</returns>
        public static DataSet GetDataSet(string commandText, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    DataSet tableDetails = new DataSet();
                    sqlCon.Open();

                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandText = commandText;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Connection = sqlCon;
                    if (parameters != null)
                    {
                        foreach (SqlParameter sparam in parameters)
                        {
                            sqlCmd.Parameters.Add(sparam);
                        }
                    }

                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd);
                    sqlAdapter.Fill(tableDetails);
                    return tableDetails;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Retrieve data table from database
        /// </summary>
        /// <param name="query">Query</param>
        /// <returns>Returns data table</returns>
        public static DataTable GetDataTableWithoutSP(string query)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(query, sqlCon);

                    DataSet tableDetails = new DataSet();
                    sqlAdapter.Fill(tableDetails);

                    return tableDetails.Tables[0];
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Execute the procedure
        /// </summary>
        /// <param name="commandText">Command Text</param>
        public static void ExecuteProcedure(string commandText)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();

                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandText = commandText;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Connection = sqlCon;
                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Execute the procedure
        /// </summary>
        /// <param name="commandText">Command Text</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>If 1 Successful,-1 Already exist, -2 Server Error, -3 Delete Fails due to foriegn key constraint</returns>
        public static int ExecuteProcedure(string commandText, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();

                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandText = commandText;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Connection = sqlCon;

                    if (parameters != null)
                    {
                        foreach (SqlParameter sparam in parameters)
                        {
                            sqlCmd.Parameters.Add(sparam);
                        }

                        sqlCmd.Parameters["@ReturnVal"].Direction = ParameterDirection.Output;
                    }
                    sqlCmd.ExecuteNonQuery();
                    return Convert.ToInt32(sqlCmd.Parameters["@ReturnVal"].Value);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Check the record exist
        /// </summary>
        /// <param name="query">query</param>
        /// <returns>Return true if exist</returns>
        public static bool IsExist(string query)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    bool flag = false;
                    SqlCommand command = new SqlCommand(query, sqlCon);
                    sqlCon.Open();

                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        flag = true;
                    }

                    dataReader.Close();
                    return flag;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// The identity insert record.
        /// </summary>
        /// <param name="query">query</param>
        /// <returns>Returns 0 If unsuccessful</returns>
        public static int IdentityInsert(string query)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    int id = 0;
                    SqlTransaction transaction = null;

                    string sql = "BEGIN ";
                    sql += query;
                    sql += ";select scope_identity(); END";

                    SqlCommand command = new SqlCommand(sql, sqlCon);
                    command.CommandType = CommandType.Text;

                    sqlCon.Open();

                    transaction = sqlCon.BeginTransaction();
                    command.Transaction = transaction;

                    object scalarResult = command.ExecuteScalar();

                    if (scalarResult != null)
                    {
                        transaction.Commit();
                        id = Convert.ToInt32(scalarResult.ToString());
                    }
                    else
                    {
                        transaction.Rollback();
                    }

                    return id;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Execute the procedure
        /// </summary>
        /// <param name="commandText">Command Text</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>If 1 Successful,-1 Already exist, -2 Server Error</returns>
        public static void ExecuteProcedureWithOutReturn(string commandText, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();

                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandText = commandText;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Connection = sqlCon;

                    if (parameters != null)
                    {
                        foreach (SqlParameter sparam in parameters)
                        {
                            sqlCmd.Parameters.Add(sparam);
                        }
                    }
                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Execute the procedure Which Get Procedure with parameter and return no of rows affected
        /// </summary>
        /// <param name="commandText">Command Text</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>no of rows affected</returns>
        /// 
        public static int ExecuteProcedureWithParameterReturnRowsAffected(string commandText, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    int rowsAffected = 0;
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandText = commandText;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Connection = sqlCon;
                    if (parameters != null)
                    {
                        foreach (SqlParameter sparam in parameters)
                        {
                            sqlCmd.Parameters.Add(sparam);
                        }
                    }
                    rowsAffected = sqlCmd.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Execute the procedure and return single value
        /// </summary>
        /// <param name="commandText">Command Text</param>
        /// <param name="parameters">SqlParameter object</param>
        public static string ExecuteProcedureAndReturnSingleValue(string commandText, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    string returnValue = "";
                    sqlCon.Open();

                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandText = commandText;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Connection = sqlCon;

                    if (parameters != null)
                    {
                        foreach (SqlParameter sparam in parameters)
                        {
                            sqlCmd.Parameters.Add(sparam);
                        }
                    }

                    returnValue = Convert.ToString(sqlCmd.ExecuteScalar());
                    return returnValue;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Execute the procedure and return single value without parameter
        /// </summary>
        /// <param name="commandText">Command Text</param>        
        public static string ExecuteProcedureAndReturnSingleValueWithoutParameter(string commandText)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    string returnValue = string.Empty;
                    sqlCon.Open();

                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandText = commandText;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Connection = sqlCon;
                    returnValue = Convert.ToString(sqlCmd.ExecuteScalar());
                    return returnValue;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Function to execute procedure for XML import
        /// </summary>
        /// <param name="commandText">string commandText</param>
        /// <param name="parameters">SqlParameter[] parameters</param>
        /// <returns>string</returns>
        public static string ExecuteProcedureforXMLImport(string commandText, SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();

                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandText = commandText;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Connection = sqlCon;

                    if (parameters != null)
                    {
                        foreach (SqlParameter sparam in parameters)
                        {
                            sqlCmd.Parameters.Add(sparam);
                        }
                        sqlCmd.Parameters["@ErrorCode"].Direction = ParameterDirection.Output;
                        sqlCmd.Parameters["@pErrorMessage"].Direction = ParameterDirection.Output;
                    }
                    sqlCmd.ExecuteNonQuery();
                    return Convert.ToString(sqlCmd.Parameters["@pErrorMessage"].Value);
                }
            }
            catch
            {
                throw;
            }
        }

        public static string ExecuteProcedureAndReturnXMLValueWithoutParameter(string commandText)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    string returnValue = string.Empty;
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand();
                    sqlCmd.CommandText = commandText;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Connection = sqlCon;
                    //returnValue = Convert.ToString(sqlCmd.ExecuteScalar());

                    using (System.Xml.XmlReader reader = sqlCmd.ExecuteXmlReader())
                    {

                        while (reader.Read())
                        {
                            returnValue = reader.ReadOuterXml();
                            // do something with s
                        }
                    }
                    return returnValue;
                }
            }
            catch
            {
                throw;
            }
        }
    }

}
