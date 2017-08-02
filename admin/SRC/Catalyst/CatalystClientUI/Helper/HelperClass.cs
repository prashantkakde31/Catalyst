using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

using System.Data;
//using System.Data.OracleClient;
using System.Web.UI.WebControls;
using System.Text;
using System.Configuration;

using System.Data.SqlClient;
using System.Security.Cryptography;

/// <summary>
/// Summary description for ABProCommonClass
/// </summary>

public class HelperClass
{
    StreamWriter sw;
    string str_ret = "";

    public HelperClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public string Admin_ChngePasswd(string rp)
    {

        //str_ret = rp.Replace(rp.Substring(13), "/MASTER/Change_Password.aspx");
        //return str_ret;
        str_ret =  "~/MASTER/Change_Password.aspx";
        return str_ret;
    }


    //public string mapLink(string rp)
    //{
    //    str_ret = rp.Replace(rp.Substring(10), "/MASTER/index.aspx");
    //    return str_ret;
    //}

    public string Default_Page(string rp)
    {
        //str_ret = rp.Replace(rp.Substring(13), "/MASTER/Home.aspx");
        //return str_ret;
        str_ret =  "../MASTER/Home.aspx";
        //str_ret = "~/Screens/Client_Dashboard.aspx";
        return str_ret;
    }

    public string ForgotPassword_Page(string rp)
    {
        //str_ret = rp.Replace(rp.Substring(13), "/MASTER/Forgot_Password.aspx");
        //return str_ret;
        str_ret = "~/MASTER/Forgot_Password.aspx";
        return str_ret;
    }

    public string mapLink(string rp)
    {
        string str_ret = null;
        //str_ret = rp.Replace(rp.Substring(13), "/MASTER/index.aspx");
        //return str_ret;
        str_ret = "~/MASTER/index.aspx";
        return str_ret;
        
    }

    private bool IsDate(string sdate)
    {
        Boolean isdate = true;
        try
        {
            DateTime dt = DateTime.Parse(sdate);
        }
        catch (Exception)
        {

            isdate = false;
        }

        return isdate;
    }

    public void WriteError(string sLastError, string sStackTrace, string sUser, string path, string sAppName, string s_Event_id = "")
    {
        //StreamReader sr = new StreamReader((path + "error/ErrorFile.txt"));
        //string buff = sr.ReadToEnd();
        //File.SetAttributes((path + "error/ErrorFile.txt"), FileAttributes.Normal);
        //sr.Close();
        //sw = File.CreateText((path + "error/ErrorFile.txt"));
        ////File.SetAttributes((path + "error/ErrorFile.txt"), FileAttributes.ReadOnly);
        //sw.WriteLine("---------------------------------------------------------------------------------------------------------------------");
        //sw.WriteLine(("Date: " + DateTime.Now));
        //sw.WriteLine(("User Id: " + sUser));
        //sw.WriteLine(("Exception Event Id: " + s_Event_id));

        ////sw.WriteLine(("Application Name: " + "Merchant Statement Solution"));
        ////Added by subhash 23-9-14
        //sw.WriteLine(("Application Name: " + "Catalyst. Management :"+sAppName));


        //sw.WriteLine(("Error Messege: " + sLastError));
        //sw.WriteLine(("Stack Trace: " + sStackTrace));
        //sw.WriteLine(" ");
        //sw.Write(buff);
        //sw.Flush();
        //sw.Close();

    }

    public void WriteLog(string sUser, string filename, string rptname, string path)
    {
    }

    public string ValidateText(string str, string fname, int len)
    {
        string functionReturnValue = null;
        //len = len + 1
        if (string.IsNullOrEmpty(str.Trim()))
        {
            functionReturnValue = "Please Enter " + fname + " It can not be NULL ";
            return functionReturnValue;
        }
        if (str.Length > len)
        {
            functionReturnValue = fname + " Can not be larger than " + len;
            return functionReturnValue;
        }
        if (str.IndexOf("<") > -1 | str.IndexOf(">") > -1)
        {
            functionReturnValue = " Less than and Greater than sign is not allowed in " + fname;
            return functionReturnValue;
        }
        functionReturnValue = "Y";
        return functionReturnValue;
    }

    public object loaddropdown(DropDownList ctr, string query, SqlConnection con, string sTextField, string sValueField)
    {
        SqlDataAdapter da = new SqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        ctr.DataTextField = sTextField;
        ctr.DataValueField = sValueField;
        ctr.DataSource = ds;
        ctr.DataBind();
        return 0;
    }

    public string ValidateToDate(string str_Date, string d_Type)
    {
        if (((str_Date.Trim() == "") || str_Date == null))
        {
            return ("Please enter " + d_Type);

        }
        if (!IsDate(str_Date))
        {
            return ("Not a valid " + d_Type);

        }
        if (!DateFormat(str_Date))
        {
            return ("Not a valid " + d_Type);

        }
        //if (str_Date.ToUpper() != string.Format("dd-MMM-yy", Convert.ToDateTime(str_Date), "dd-MMM-yy").ToUpper())
        //{
        //    return "Invalid From Date";

        //}
        // If date_check(str_Date) <> 1 Then
        //     ValidateToDate = "Enter Prpoer " & d_Type
        //     Exit Function
        // End If
        return "Y";
    }

    public string ValidateDate(string str_Date, string d_Type)
    {
        string functionReturnValue = null;
        if (string.IsNullOrEmpty(str_Date.Trim()) || str_Date == null)
        {

            functionReturnValue = "Please enter " + d_Type;
            return functionReturnValue;
        }
        if (!IsDate(str_Date))
        {
            functionReturnValue = "Not a valid " + d_Type;
            return functionReturnValue;
        }
        if (!IsDate(str_Date))
        {
            functionReturnValue = "Not a valid " + d_Type;
            return functionReturnValue;
        }

        if (str_Date.ToUpper() != String.Format("dd-MMM-yy", Convert.ToDateTime(str_Date)).ToUpper())
        {


            functionReturnValue = "Invalid " + d_Type + "Date";
            return functionReturnValue;
        }
        //If date_check(str_Date) <> 1 Then
        //    ValidateDate = "Enter Prpoer " & d_Type
        //    Exit Function
        //End If
        if (Convert.ToDateTime(str_Date) > DateTime.Now)
        {
            functionReturnValue = d_Type + " should not be greater than today";
            return functionReturnValue;
        }
        functionReturnValue = "Y";
        return functionReturnValue;
    }

    public string ValidateMonDate(string str_Date, string d_Type)
    {
        string functionReturnValue = null;
        if (string.IsNullOrEmpty(str_Date.Trim()) || str_Date == null)
        {
            functionReturnValue = "Please enter " + d_Type;
            return functionReturnValue;
        }
        if (!IsDate(str_Date))
        {
            functionReturnValue = "Not a valid " + d_Type;
            return functionReturnValue;
        }

        if (str_Date.ToUpper() != String.Format("MMMyyyy", Convert.ToDateTime(str_Date)).ToUpper())
        {
            functionReturnValue = "Invalid " + d_Type + "Date";
            return functionReturnValue;
        }

        functionReturnValue = "Y";
        return functionReturnValue;
    }

    public string ValidateFromDateToDate(string str_FromDate, string str_ToDate)
    {
        string functionReturnValue = null;
        if (string.IsNullOrEmpty(str_FromDate.Trim()) || str_FromDate == null)
        {
            functionReturnValue = "Please enter From date";
            return functionReturnValue;
        }
        if (!IsDate(str_FromDate))
        {
            functionReturnValue = "Not a valid From date";
            return functionReturnValue;
        }
        if (Convert.ToDateTime(str_FromDate) > DateTime.Now)
        {
            functionReturnValue = "From date should not be greater than today";
            return functionReturnValue;
        }
        if (string.IsNullOrEmpty(str_ToDate.Trim()) || str_ToDate == null)
        {
            functionReturnValue = "Please enter To date";
            return functionReturnValue;
        }
        if (!IsDate(str_ToDate))
        {
            functionReturnValue = "Not a valid To date";
            return functionReturnValue;
        }
        //if (str_FromDate.ToUpper() != String.Format("dd-MMM-yy", Convert.ToDateTime(str_FromDate)).ToUpper())
        //{
        //    functionReturnValue = "Invalid From Date";
        //    return functionReturnValue;
        //}
        //if (str_ToDate.ToUpper() != String.Format("dd-MMM-yy", Convert.ToDateTime(str_ToDate)).ToUpper())
        //{
        //    functionReturnValue = "Invalid To Date";
        //    return functionReturnValue;
        //}
        //If date_check(str_FromDate) <> 1 Then
        //    ValidateFromDateToDate = "Enter Prpoer From Date"
        //    Exit Function
        //End If
        //If date_check(str_ToDate) <> 1 Then
        //    ValidateFromDateToDate = "Enter Prpoer To Date"
        //    Exit Function
        //End If
        if (Convert.ToDateTime(str_ToDate) > DateTime.Now)
        {
            functionReturnValue = "To date should not be greater than today";
            return functionReturnValue;
        }
        if (Convert.ToDateTime(str_ToDate) < Convert.ToDateTime(str_FromDate))
        {
            functionReturnValue = "To date should not be less than From date";
            return functionReturnValue;
        }
        functionReturnValue = "Y";
        return functionReturnValue;
    }

    public bool DateFormat(string str_Date)
    {
        bool functionReturnValue = false;
        if (str_Date.Length != 9)
        {
            functionReturnValue = false;
            return functionReturnValue;
        }
        if (!(ValidateNumber(str_Date.Substring(0, 2)) & str_Date.Substring(2, 1) == "-" & str_Date.Substring(6, 1) == "-" & ValidateNumber(str_Date.Substring(7, 2))))
        {
            functionReturnValue = false;
        }
        else
        {
            functionReturnValue = true;
        }
        return functionReturnValue;
    }

    public string fnstrict_number(string str2, string fname, int len)
    {
        string functionReturnValue = null;
        if (string.IsNullOrEmpty(str2.Trim()))
        {
            functionReturnValue = "Please Enter " + fname + " It can not be NULL ";
            return functionReturnValue;
        }
        if (str2.Length > len)
        {
            functionReturnValue = fname + " Can not be larger than " + len;
            return functionReturnValue;
        }
        if (str2.IndexOf("<") > -1 | str2.IndexOf(">") > -1)
        {
            functionReturnValue = " Less than and Greater than sign is not allowed in " + fname;
            return functionReturnValue;
        }

        if (fnonly_num(str2) != str2.Length)
        {
            functionReturnValue = fname + " must be Number";
            return functionReturnValue;
        }
        functionReturnValue = "Y";
        return functionReturnValue;
    }


    public bool ValidateNumber(string str_Num)
    {
        Int16 str_Len = default(Int16);
        bool Flag = false;
        Flag = true;
        for (str_Len = 0; str_Len <= str_Num.Length - 1; str_Len++)
        {
            switch (str_Num.Substring(str_Len, 1))
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    break;
                default:
                    Flag = false;
                    break;
            }

        }
        return Flag;
    }


    public string ValidateFromDate(string str_Date, string d_Type)
    {
        string functionReturnValue = null;
        if (string.IsNullOrEmpty(str_Date.Trim()) || str_Date == null)
        {
            functionReturnValue = "Please enter " + d_Type;
            return functionReturnValue;
        }
        if (!IsDate(str_Date))
        {
            functionReturnValue = "Not a valid " + d_Type;
            return functionReturnValue;
        }
        if (!DateFormat(str_Date))
        {
            functionReturnValue = "Not a valid " + d_Type;
            return functionReturnValue;
        }
        if (str_Date.ToUpper() != String.Format("dd-MMM-yy", Convert.ToDateTime(str_Date)).ToUpper())
        {
            functionReturnValue = "Invalid From Date";
            return functionReturnValue;

        }
        //If date_check(str_Date) <> 1 Then
        //    ValidateFromDate = "Enter Prpoer " & d_Type
        //    Exit Function
        //End If
        if (Convert.ToDateTime(str_Date) > DateTime.Now)
        {
            functionReturnValue = d_Type + " should not be greater than today";
            return functionReturnValue;
        }
        functionReturnValue = "Y";
        return functionReturnValue;
    }


    public string CheckSession(string Session, string Screen)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
        if (con.State == ConnectionState.Closed)
            con.Open();
        //Modified By sunil on 09-04-10
        //Dim cmdchk As New OracleCommand("SELECT Checkuser(:sUSERNAME ,:sSCREENNAME) FROM DUAL", con)
        //SqlCommand cmdchk = new SqlCommand("SELECT Checkuser_NEW(@sUSERNAME ,@sSCREENNAME) FROM DUAL", con);
        SqlCommand cmdchk = new SqlCommand("SELECT dbo.Checkuser_NEW(@sUSERNAME ,@sSCREENNAME)", con);
        //SELECT Checkuser_NEW(:sUSERNAME ,:sSCREENNAME) FROM DUAL
        SqlParameter prmSession = new SqlParameter("@sUSERNAME", SqlDbType.VarChar);
        SqlParameter prmScreen = new SqlParameter("@sSCREENNAME", SqlDbType.VarChar);
        prmSession.Value = Session;
        prmScreen.Value = Screen;
        cmdchk.Parameters.Add(prmSession);
        cmdchk.Parameters.Add(prmScreen);
        string strchk = cmdchk.ExecuteScalar().ToString();
        return strchk;
    }


    public string only_text_no_num(string str, string fname, int len)
    {
        string functionReturnValue = null;
        //len = len + 1
        if (string.IsNullOrEmpty(str.Trim()))
        {
            functionReturnValue = "Please Enter " + fname + " It can not be NULL ";
            return functionReturnValue;
        }
        if (str.Length > len)
        {
            functionReturnValue = fname + " Can not be larger than " + len;
            return functionReturnValue;
        }
        if (str.IndexOf("<") > -1 | str.IndexOf(">") > -1)
        {
            functionReturnValue = " Less than and Greater than sign is not allowed in " + fname;
            return functionReturnValue;
        }

        if (fnonly_num(str) != 0)
        {
            functionReturnValue = fname + "can not contain number";
            return functionReturnValue;
        }
        functionReturnValue = "Y";
        return functionReturnValue;
    }


    public string fnstrict_number_len(string str2, string fname, int len)
    {
        string functionReturnValue = null;
        if (string.IsNullOrEmpty(str2.Trim()))
        {
            functionReturnValue = "Please Enter " + fname + " It can not be NULL ";
            return functionReturnValue;
        }
        if (str2.Length != len)
        {
            functionReturnValue = fname + " must be of " + len + " digits";
            return functionReturnValue;
        }
        if (str2.IndexOf("<") > -1 | str2.IndexOf(">") > -1)
        {
            functionReturnValue = " Less than and Greater than sign is not allowed in " + fname;
            return functionReturnValue;
        }

        if (fnonly_num(str2) != str2.Length)
        {
            functionReturnValue = fname + " must be Numeric";
            return functionReturnValue;
        }
        functionReturnValue = "Y";
        return functionReturnValue;
    }

    private int fnonly_num(string str1)
    {
        Int16 str_Len = default(Int16);
        int cnt = 0;
        for (str_Len = 0; str_Len <= str1.Length - 1; str_Len++)
        {
            switch (str1.Substring(str_Len, 1))
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    cnt = cnt + 1;
                    break;
                default:

                    break;
            }
        }
        return cnt;
    }

    public bool chkdecimal(string strdec)
    {
        Boolean ret = false;
        int cnt = strdec.IndexOf(".");
        if (cnt >= 0)
        {
            ret = true;
        }
        return ret;
    }


    private string ScrtptCheck(string str)
    {
        string functionReturnValue = null;
        if (str.ToLower().Contains("<script>"))
        {
            functionReturnValue = "Script not Allowed";
            return functionReturnValue;
        }
        functionReturnValue = "Y";
        return functionReturnValue;
    }

    public void writeLogDB(string sUser, string filename, string rptname)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringV"].ToString());
        if ((conn.State == ConnectionState.Closed))
        {
            conn.Open();
        }
        SqlCommand Log = new SqlCommand("insert into admin_report_log values(@sUser,@fname,@rptName,getdate())", conn);
        Log.Parameters.AddWithValue("@sUser", sUser);
        Log.Parameters.AddWithValue("@fname", filename);
        Log.Parameters.AddWithValue("@rptName", rptname);
        Log.ExecuteNonQuery();
        conn.Close();
        Log.Parameters.Clear();
        Log.Dispose();
    }
    public string Encrypt(string clearText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (System.IO.MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }

    public string Decrypt(string cipherText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }
}

