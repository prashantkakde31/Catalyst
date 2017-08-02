using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

using System.Data;
using System.Configuration;
using System.Security.Cryptography;
using System.IO;
using System.Text;


/// <summary>
/// Summary description for AdminClass
/// </summary>
public class AdminClass
{
    public AdminClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringV"]);

    public void UpateSessionInfo(int mIndex)
    {
        string sqlUpdateSessionInfo = ("update SESSION_TRACKING_LOG set LOGOUTAT =getdate() where INDEXNO = \'"
                    + (mIndex + "\'"));
        SqlCommand cmdInsertSessionInfo = new SqlCommand(sqlUpdateSessionInfo, conn);
        if ((conn.State == ConnectionState.Closed))
        {
            conn.Open();
        }
        cmdInsertSessionInfo.ExecuteNonQuery();
        conn.Close();
        // conn.Dispose()
    }

    public void Test()
    {
        // INDEXNO, USERNAME, HOSTNAME, LOGINAT, LOGOUTAT
        string sqlUpdateSessionInfo = "insert into SESSION_TRACKING_LOG values(00,\'11\',\'11\',sysdate,sysdate)";
        SqlCommand cmdInsertSessionInfo = new SqlCommand(sqlUpdateSessionInfo, conn);
        if ((conn.State == ConnectionState.Closed))
        {
            conn.Open();
        }
        cmdInsertSessionInfo.ExecuteNonQuery();
        conn.Close();
        // conn.Dispose()
    }

    public void INSERT_INTO_TRAIL(string SFORUSER, string SBYUSER, string SACTION)
    {
        string SiNSERT = ("INSERT INTO ADMIN_MAPS_USER_ACTION_TRAIL (USER_NAME, UPDATED_BY, ACTION, ACTION_DATE) VALUES(\'"
                    + (SFORUSER + ("\',\'"
                    + (SBYUSER + ("\',\'"
                    + (SACTION + "\',getdate() )"))))));
        if ((conn.State == ConnectionState.Closed))
        {
            conn.Open();
        }
        SqlCommand CMDi = new SqlCommand(SiNSERT, conn);
        CMDi.ExecuteNonQuery();
        conn.Close();
        // conn.Dispose()
    }

    public string Check_PageAccess(string _Username, string _ScreenName)
    {
        string _StrAccess = "";
        if ((_Username == "ADMIN"))
        {
            _StrAccess = ("SELECT COUNT(1) FROM  " + ("(SELECT upper(SUBSTR(WEBPAGE,INSTRC(WEBPAGE,\'/\',1,2)+1)) WEBPAGE FROM CRM_MENU_MASTER_WEB " + ("WHERE PARENTITEMID in (\'101\',\'201\',\'301\'))  " + ("WHERE WEBPAGE =upper(\'"
                        + (_ScreenName + "\') ")))));
        }
        else if ((_Username == "ADMIN"))
        {
            _StrAccess = ("SELECT COUNT(1) FROM  " + ("(SELECT upper(SUBSTR(WEBPAGE,INSTRC(WEBPAGE,\'/\',1,2)+1)) WEBPAGE FROM CRM_MENU_MASTER_WEB " + ("WHERE PARENTITEMID in (\'201\',\'101\')) " + ("WHERE WEBPAGE =upper(\'"
                        + (_ScreenName + "\') ")))));
        }
        else if ((_Username == "OPERATOR"))
        {
            _StrAccess = ("SELECT COUNT(1) FROM  " + ("(SELECT upper(SUBSTR(WEBPAGE,INSTRC(WEBPAGE,\'/\',1,2)+1)) WEBPAGE FROM CRM_MENU_MASTER_WEB " + ("WHERE PARENTITEMID= 101 AND ITEMID=1008)  " + ("WHERE WEBPAGE =upper(\'"
                        + (_ScreenName + "\') ")))));
        }
        else
        {
            _StrAccess = ("SELECT COUNT(1) FROM  " + ("(SELECT upper(SUBSTR(WEBPAGE,INSTRC(WEBPAGE,\'/\',1,2)+1)) WEBPAGE FROM CRM_MENU_MASTER_WEB " + ("WHERE PARENTITEMID= 301) " + ("WHERE WEBPAGE =upper(\'"
                        + (_ScreenName + "\') ")))));
        }
        SqlCommand _CmdAccess = new SqlCommand(_StrAccess, conn);

        int _CountAccess;
        if ((conn.State == ConnectionState.Closed))
        {
            conn.Open();
        }
        _CountAccess = Convert.ToInt32(_CmdAccess.ExecuteScalar());
        if ((conn.State == ConnectionState.Open))
        {
            conn.Close();
        }
        return _CountAccess.ToString();
    }

    
}