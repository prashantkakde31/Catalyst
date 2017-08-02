using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Xml;

using System.Text.RegularExpressions;
using ICSharpCode.SharpZipLib;
using Microsoft.VisualBasic;

/// <summary>
/// Summary description for Reports
/// </summary>
public class Reports
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conn"]);

    public Reports()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void WriteToExcel(string Dir, string Filename, string Xslname, string Query, Int16 Limit)
    {
        DataSet ds = new DataSet();
        // Dim fn, str As String
        string str = null;
        long i = 0;
        long j = 0;
        //Dim d As Directory
        j = 0;
        SqlDataAdapter da = new SqlDataAdapter(Query, con);
        da.Fill(ds);
        da.Dispose();
        if (!Directory.Exists(Dir))
        {
            Directory.CreateDirectory(Dir);
        }

        for (i = 1; i <= ds.Tables[0].Rows.Count; i += Limit)
        {
            str = Query + " and  num between " + i + " and " + (i + Limit - 1);
            SqlDataAdapter da1 = new SqlDataAdapter(str, con);
            DataSet DS2 = new DataSet();
            da1.Fill(DS2);
            XmlDataDocument xdd = new XmlDataDocument(DS2);
            //Dim xt As New Xsl.XslTransform
            System.Xml.Xsl.XslTransform xt = new System.Xml.Xsl.XslTransform();
            xt.Load(Xslname);
            FileStream fs = new FileStream(Dir + "\\" + Filename + j + ".xls", System.IO.FileMode.CreateNew, System.IO.FileAccess.Write);
            XmlUrlResolver rs = new XmlUrlResolver();
            rs.Credentials = System.Net.CredentialCache.DefaultCredentials;
            xt.Transform(xdd, null, fs, rs);
            fs.Close();
            j = j + 1;
            DS2.Dispose();
        }
    }

    public void WriteToExcelNew(DataSet Data_Set, string path, string filename)
    {
        // Try

        StreamWriter Sw = default(StreamWriter);
        DataRow DR = default(DataRow);
        //Dim str, fn, s As String
        //            Dim str, s As String
        string s = null;
        string str = "";
        int I = 0;
        int J = 0;
        int x = 0;
        int i1 = 0;
        int i2 = 0;
        int no = 0;
        int page = 0;
        string PATH1 = path + "\\";
        no = 1;
        page = 0;
        x = Data_Set.Tables[0].Columns.Count;
        J = Data_Set.Tables[0].Rows.Count;
        if (J == 0)
        {
            Sw = File.CreateText(PATH1 + filename + ".xls");
            for (i2 = 0; i2 <= x - 1; i2++)
            {
                str += Data_Set.Tables[0].Columns[i2].ColumnName + "\t";
            }
            Sw.WriteLine(str);

        }
        else
        {
            for (I = 0; I <= J - 1; I++)
            {
                if ((page % 60000 == 0 | page == 0))
                {
                    if (page != 0)
                    {
                        Sw.Close();
                    }
                    if (no > 1)
                    {
                        Sw = File.CreateText(PATH1 + filename + no + ".xls");
                    }
                    else
                    {
                        Sw = File.CreateText(PATH1 + filename + ".xls");
                    }
                    //If page <> 0 Then
                    //    Sw.Close()
                    //End If


                    no = no + 1;
                    for (i2 = 0; i2 <= x - 1; i2++)
                    {
                        str += Data_Set.Tables[0].Columns[i2].ColumnName + "\t";
                    }
                    Sw.WriteLine(str);
                    str = "";
                }
                page = page + 1;
                DR = Data_Set.Tables[0].Rows[I];
                for (i1 = 0; i1 <= x - 1; i1++)
                {
                    if (DR[i1] == null)
                    {
                        s = " ";
                    }
                    else
                    {
                        s = DR[i1].ToString();
                    }

                    if (Regex.IsMatch(s, @"^\d{9}$"))
                    {
                        if ((Math.Round(Convert.ToDouble(s), 0).ToString()).Length > 10)
                        {
                            str += "'" + s + "\t";
                        }
                        else
                        {
                            str += "" + s + "\t";
                        }
                    }
                    else
                    {
                        str += "" + s + "\t";
                    }

                }
                Sw.WriteLine(str);
                str = "";
            }
        }
        Sw.Close();
        //Catch ex As Exception

        // Finally
        //  If con.State = ConnectionState.Open Then con.Close()
        // End Try
    }

    public void create_zip(string path, string filename, string type)
    {
        string fileNew;
        // Try
        fileNew = (filename + ".zip");
        //string f;
        string[] fname = Directory.GetFiles(path, type);
        ICSharpCode.SharpZipLib.Zip.ZipOutputStream zipoutputstream = new ICSharpCode.SharpZipLib.Zip.ZipOutputStream(File.Create((path + fileNew)));
        zipoutputstream.SetLevel(6);
        ICSharpCode.SharpZipLib.Checksums.Crc32 objcrc32 = new ICSharpCode.SharpZipLib.Checksums.Crc32();
        foreach (string f in fname)
        {
            FileStream stream = File.OpenRead(f);
            byte[] buff = new byte[stream.Length];
            ICSharpCode.SharpZipLib.Zip.ZipEntry zipentry = new ICSharpCode.SharpZipLib.Zip.ZipEntry(f.Substring((f.LastIndexOf("\\") + 1)));
            //stream.Read(buff, 0, buff.Length);
            stream.Read(buff, 0, buff.Length);
            zipentry.DateTime = DateTime.Now;
            zipentry.Size = stream.Length;
            stream.Close();
            objcrc32.Reset();
            objcrc32.Update(buff);
           // zipentry.Crc = objcrc32.Value;
            zipoutputstream.PutNextEntry(zipentry);
            zipoutputstream.Write(buff, 0, buff.Length);
        }
        zipoutputstream.Flush();
        zipoutputstream.Finish();
        zipoutputstream.Close();
    }

    public void deletedumpxl(string path, string type)
    {
        //string f;
        //string[] fname = Directory.GetFiles(Path, "*.xls");

        string[] fname = Directory.GetFiles(path, type);

        foreach (string f in fname)
        {
            File.Delete(f);
        }
    }
    public void WriteToExcel_By_DS(DataSet DS1, string path, string filename)
    {
        //  this function is used for wiring data in excel..... ds will be called which is alrady filled.  Waheed
        // Try
        StreamWriter Sw;
        DataRow DR;
        // Dim str, fn, s As String
        string str = "";
        string s;
        int I;
        int J;
        int x;
        int i1;
        int i2;
        int no;
        int page;
        string PATH1 = (path + "\\");
        no = 1;
        page = 0;
        x = DS1.Tables[0].Columns.Count;
        J = DS1.Tables[0].Rows.Count;
        if (J == 0)
            return;
        //if (J != 0)
        //{
        Sw = File.CreateText((PATH1 + (filename + ".xls")));
        for (i2 = 0; (i2 <= (x - 1)); i2++)
        {
            str = str + DS1.Tables[0].Columns[i2].ColumnName + "\t";
        }
        Sw.WriteLine(str);
        //}
        //else
        //{
        for (I = 0; (I <= (J - 1)); I++)
        {
            if ((((page % 60000) == 0) || (page == 0)))
            {
                if ((page != 0))
                {
                    Sw.Close();
                }
                if ((no > 1))
                {
                    Sw = File.CreateText((PATH1 + (filename + (no + (" - " + (DateTime.Now.ToString("dd-MMM-yy") + ".xls"))))));
                }
                else
                {
                    Sw = File.CreateText((PATH1 + (filename + (" - " + (DateTime.Now.ToString("dd-MMM-yy") + ".xls")))));
                }
                // If page <> 0 Then
                //     Sw.Close()
                // End If
                no = (no + 1);
                for (i2 = 0; (i2 <= (x - 1)); i2++)
                {
                    str = str + DS1.Tables[0].Columns[i2].ColumnName + "\t";
                }
                Sw.WriteLine(str);
                str = "";
            }
            page = (page + 1);
            DR = DS1.Tables[0].Rows[I];
            for (i1 = 0; (i1 <= (x - 1)); i1++)
            {
                if (Information.IsDBNull(DR[i1]))
                {
                    s = " ";
                }
                else
                {
                    s = DR[i1].ToString();
                }
                if (Information.IsNumeric(s))
                {
                    if ((Math.Round(Convert.ToDouble(s), 0).ToString().Length > 10))
                        str = str + "\'" + s + "\t";
                    else
                        str = str + "" + s + "\t";

                }
                else
                {
                    str = str + "" + s + "\t";
                }
            }
            Sw.WriteLine(str);
            str = "";
        }
        //}
        Sw.Close();
        Sw.Dispose();
        // Catch ex As Exception
        // Finally
        //   If con.State = ConnectionState.Open Then con.Close()
        // End Try
    }
}