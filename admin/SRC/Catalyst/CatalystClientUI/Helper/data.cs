// ***********************************************************************************************************************                                  
//  File Name            : < data class>
//  Location             : In-Solutions Global Pvt. Ltd., Malad                               
//  Author               : UNKNOWN 
//  PADss Created        : <SONALI MAYEKAR>, Emp. No: <C1003>
//  Date of Creation     : 
//  PADss Date           : <02-06-10>
//  Description          : data class
// ***********************************************************************************************************************
using System.Data;
using System.Web;
using System.Web.UI;

using System.Data.SqlClient;
using System.Configuration;

public class data
{

    public static SqlConnection connect = new SqlConnection(ConfigurationManager.AppSettings["conn"]);

    public data()
    {
        if (connect.State == ConnectionState.Closed)
            
            connect.Open();
    }

    public DataSet GetData(string Query)
    {
        SqlDataAdapter da = new SqlDataAdapter(Query, connect);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }

    public void ExQuery(string Query)
    {
        SqlCommand cmd = new SqlCommand(Query, connect);
        //         cmd.ExecuteNonQuery()
        cmd.ExecuteNonQuery();
    }

    public void ExQuery(SqlCommand cmd)
    {
        cmd.Connection = connect;
        // cmd.ExecuteNonQuery()
        cmd.ExecuteNonQuery();
    }

    public SqlDataReader ExReader(string str)
    {
        SqlCommand cmd = new SqlCommand(str, connect);
        SqlDataReader MyRead;
        MyRead = cmd.ExecuteReader();
        return MyRead;
    }

    // Public Function ExScalar(ByVal str As String) As Integer
    //     Dim cmd As New SqlCommand(str, connect)
    //     Dim Count As Integer
    //     Count = cmd.ExecuteScalar
    //     Return Count
    // End Function
    public string ExScalar(string str)
    {
        SqlCommand cmd = new SqlCommand(str, connect);
        string Count;
        Count = cmd.ExecuteScalar().ToString();
        return Count;
    }

    public static void Display(string str, System.Web.UI.Page currPg)
    {
        currPg.Response.Write(("<script language=javascript>alert(\' "
                        + (str + " \')</script>")));
    }

    public static void CLOSE()
    {
        connect.Close();
        // connect.Dispose()
        connect = null;
    }
}
// ***********************************************************************************************************************
// End of <CHBKRefundScreen>
// ***********************************************************************************************************************