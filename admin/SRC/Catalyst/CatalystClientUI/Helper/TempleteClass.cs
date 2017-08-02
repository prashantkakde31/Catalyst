using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.Runtime.InteropServices;
using System.Collections;
using System.Text;
using Microsoft.VisualBasic;
using ICSharpCode.SharpZipLib.Core;
using System.Globalization;

/// <summary>
/// Summary description for TempleteClass
/// </summary>
public class TempleteClass
{
    //OracleCommand cmd = new OracleCommand();
    //FIRC_Helper Firc = new FIRC_Helper();
    Microsoft.Office.Interop.Excel.Application oexcel;
    Microsoft.Office.Interop.Excel.Workbook obook;
    Microsoft.Office.Interop.Excel.Worksheet osheet;
    string[] array = new string[9] { "Report Name", "Report For", "Report Generation Date", "From Date", "To Date", "Product Name", "Card Type", "Card Variant", "Bank Name" };
    int colcount;
    public TempleteClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //public void LoungeExcelWrite(string FnameWithPath, SqlDataReader dr, string type, string[] val)
    //{
    //    StreamWriter sw;
    //    Int16 i, j, k = 0;
    //    int trxn = 0;
    //    double amount = 0;

    //    if ((dr.HasRows == false))
    //    {
    //        // return;
    //    }
    //    // sw = New StreamWriter(FnameWithPath)

    //    sw = File.AppendText(FnameWithPath);
    //    // StreamWriter sw= File.AppendText(Server.MapPath("").ToString() + "\\test.txt")
    //    // sw.WriteLine("<html><head><style> <!-- td     { padding-top:1px; } .text {mso-style-parent:style0;mso-number-format:""\@"";} .number {mso-style-parent:style0;      mso-number-format:""\#\,\#\#0\.00\;\[Red\]\#\,\#\#0\.00"";}--> </style>")
    //    sw.WriteLine(@"<html><head><style> <!-- td     { padding-top:1px; } .text {mso-style-parent:style0;mso-number-format:""\@"";} .number {mso-style-parent:style0;      mso-number-format:Standard;}  .date{mso-style-parent:style0;mso-number-format:""\[ENG\]\[$-409\]d\\-mmm\\-yy\;\@"";}--> </style>");
    //    sw.WriteLine(@"<!--[if gte mso 9]><xml> <x:ExcelWorkbook>  <x:ExcelWorksheets>   <x:ExcelWorksheet>    <x:Name>Sheet1</x:Name>   <x:WorksheetOptions> <x:Selected/> <x:DisplayGridlines/> </x:WorksheetOptions> </x:ExcelWorksheet> </x:ExcelWorksheets> </x:ExcelWorkbook> </xml><![endif]--> </head><body><table border=1 bordercolor=ActiveBorder>");
    //    if ((type == "csv"))
    //    {

    //    }
    //    else
    //    {
    //        colcount = dr.FieldCount;//decide no of colums

    //        sw.WriteLine("<tr>");

    //        sw.WriteLine("<td><img src='NPCI.JPG' alt='Smiley face' height='40' width='150'></td></tr>");
    //        for (i = 0; i < 9; i++)
    //        {
    //            sw.WriteLine("<tr>");
    //            sw.WriteLine("<td></td>");
    //            sw.WriteLine("<td></td>");
    //            sw.WriteLine("<td align=left><b>" + array[k] + ":</b></td>");
    //            sw.WriteLine("<td></td>");
    //            sw.WriteLine("<td align=left class=text>" + val[k] + "</td>");
    //            for (j = 0; j < colcount - 5; j++)
    //            {
    //                sw.WriteLine(("<td></td>"));
    //            }
    //            sw.WriteLine("</tr>");
    //            k++;
    //        }
    //        sw.WriteLine("<tr>");
    //        sw.WriteLine("<td colspan=" + colcount + " align=center><b>Note: Amount is applicable only for Approved transactions.</b></td>");
    //        sw.WriteLine("</tr>");
    //        sw.WriteLine("<tr>");
    //        sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8><b>Year:" + DateTime.Now.Year + "</b></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 7) + " align=center bgcolor=#D8D8D8><b>RuPay Transactions Details</b></td><td bgcolor=#D8D8D8></td>");
    //        sw.WriteLine("</tr>");
    //        sw.WriteLine("<tr>");
    //        for (i = 0; (i <= (dr.FieldCount - 1)); i++)
    //        {
    //            sw.WriteLine(("<th bgcolor=#D8D8D8>" + dr.GetName(i)));
    //        }
    //    }
    //    sw.WriteLine("<tr>");
    //    for (i = 0; i < colcount; i++)
    //        sw.WriteLine("<td bgcolor=#D8D8D8></td>");
    //    sw.WriteLine("</tr>");

    //    while (dr.Read())
    //    {
    //        sw.WriteLine("<tr bordercolor=ActiveBorder style=\'height:12.95pt;\'>");
    //        for (i = 0; (i <= (dr.FieldCount - 1)); i++)
    //        {
    //            if (i == 19)
    //            {
    //                amount = amount + Convert.ToInt32(dr[i]);
    //            }
    //            sw.WriteLine(("<td bordercolor=ActiveBorder class=text align=center>" + dr[i]));

    //        }
    //        trxn = trxn + 1;
    //    }

    //    //  Total Write ....
    //    sw.WriteLine("<tr align=center>");
    //    sw.WriteLine("<td></td><td><b>TOTAL:</td><td><b>" + trxn.ToString() + "</td>");
    //    for (i = 0; i < colcount - 3; i++)
    //    {
    //        if (i == 16)
    //            sw.WriteLine("<td><b>" + amount.ToString() + "</td>");
    //        else
    //            sw.WriteLine("<td></td>");
    //    }
    //    sw.WriteLine("</tr>");
    //    sw.WriteLine("<tr>");
    //    sw.WriteLine("<td colspan=2><b>End Of Report<b></td>");
    //    for (i = 0; i < colcount - 3; i++)
    //        sw.WriteLine("<td></td>");
    //    sw.WriteLine("</tr>");
    //    sw.Close();

    //    //Enable_Security(FnameWithPath);
    //}

    public void LoungeExcelWrite(string FnameWithPath, SqlDataReader dr, string type, string[] val, string IMG,string  Bankflag,string year)
    {
        StreamWriter sw;
        Int16 i, j, k = 0;
        int trxn = 0;
        string amt = "Transaction Amount";
        double tranamt = 0.00;
        string flag = "N";//check whether tran amount column exists or not
        var columns = new List<string>() { "Access Fees to be paid by NPCI(Fees To be applied as per the Lounge Rate List)", "Access Fees to be paid to vendor(Fees To be applied as per the Lounge Rate List)", "Total Amount of Approved Transactions", "TXN AMT" };

        Dictionary<string, double> sums = new Dictionary<string, double>();
        if ((dr.HasRows == false))
        {
            return;
        }
        // sw = New StreamWriter(FnameWithPath)


        //Write Data
        sw = File.AppendText(FnameWithPath);
        // StreamWriter sw= File.AppendText(Server.MapPath("").ToString() + "\\test.txt")
        // sw.WriteLine("<html><head><style> <!-- td     { padding-top:1px; } .text {mso-style-parent:style0;mso-number-format:""\@"";} .number {mso-style-parent:style0;      mso-number-format:""\#\,\#\#0\.00\;\[Red\]\#\,\#\#0\.00"";}--> </style>")
        sw.WriteLine(@"<html><head><style> <!-- td     { padding-top:1px; } .text {mso-style-parent:style0;mso-number-format:""\@"";} .number {mso-style-parent:style0;      mso-number-format:General;}  .date{mso-style-parent:style0;mso-number-format:""\[ENG\]\[$-409\]d\\-mmm\\-yy\;\@"";}--> </style>");
        sw.WriteLine(@"<!--[if gte mso 9]><xml> <x:ExcelWorkbook>  <x:ExcelWorksheets>   <x:ExcelWorksheet>    <x:Name>Sheet1</x:Name>   <x:WorksheetOptions> <x:Selected/> <x:DisplayGridlines/> </x:WorksheetOptions> </x:ExcelWorksheet> </x:ExcelWorksheets> </x:ExcelWorkbook> </xml><![endif]--> </head><body><table border=1 bordercolor=ActiveBorder>");
        if ((type == "csv"))
        {

        }
        else
        {
            colcount = dr.FieldCount;//decide no of colums

            sw.WriteLine("<tr>");
            sw.WriteLine("<td colspan=2></td></tr>");
            for (i = 0; i < 9; i++)
            {
                sw.WriteLine("<tr>");
                sw.WriteLine("<td></td>");
                sw.WriteLine("<td></td>");
                sw.WriteLine("<td align=left><b>" + array[k] + ":</b></td>");
                sw.WriteLine("<td align=left class=text>" + val[k] + "</td>");
                if (k == 3 || k == 4)
                {
                    sw.WriteLine("<td align=left><b>(Transaction Date) </td>");
                    for (j = 0; j < colcount - 5; j++)
                        sw.WriteLine(("<td></td>"));
                }
                else
                {
                    for (j = 0; j < colcount - 4; j++)
                        sw.WriteLine(("<td></td>"));
                }
                sw.WriteLine("</tr>");
                k++;
            }
            sw.WriteLine("<tr>");
            for (i = 0; i < colcount; i++)
                sw.WriteLine("<td></td>");
            sw.WriteLine("</tr>");
            sw.WriteLine("<tr>");
            sw.WriteLine("<td colspan=" + colcount + " align=left style='margin-left:500px;'><b>Note: Amount is applicable only for Approved transactions.</b></td>");
            sw.WriteLine("</tr>");
            sw.WriteLine("<tr>");
            if ( Bankflag == "Y")
                //sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8 align=center><b>Year:" + year + "</b></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 6) + " align=left style='margin-left:500px;' bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td>");
                sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8 align=center><b>Year:" + year + "</b></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 6) + " align=left style='margin-left:500px;' bgcolor=#D8D8D8><b>RuPay Transactions Details</b></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td>");
            else
                sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8 align=center><b>Year:" + year + "</b></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 6) + " align=left style='margin-left:500px;' bgcolor=#D8D8D8><b>RuPay Transactions Details</b></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td>");
         
            sw.WriteLine("</tr>");
            sw.WriteLine("<tr>");
            for (i = 0; (i <= (dr.FieldCount - 1)); i++)
            {
                sw.WriteLine(("<th bgcolor=#D8D8D8>" + dr.GetName(i)));
                if (columns.Contains(dr.GetName(i).ToString()))
                    sums.Add(dr.GetName(i).ToString(), 0);
                if (dr.GetName(i).ToString().Equals(amt))
                    flag = "Y";

            }
        }

        sw.WriteLine("<tr>");
        for (i = 0; i < colcount; i++)
            sw.WriteLine("<td bgcolor=#D8D8D8></td>");
        sw.WriteLine("</tr>");

        while (dr.Read())
        {
            sw.WriteLine("<tr bordercolor=ActiveBorder style=\'height:12.95pt;\'>");
            for (i = 0; (i <= (dr.FieldCount - 1)); i++)
            {
                //if(Information.IsNumeric(dr[i].ToString())==true)
                //    sw.WriteLine(("<td bordercolor=ActiveBorder class=number align=center>" + dr[i]));
                //else
                sw.WriteLine(("<td bordercolor=ActiveBorder class=text align=center>" + dr[i]));

                if (columns.Contains(dr.GetName(i).ToString()))
                {
                    //double old = sums[dr.GetName(i).ToString()];
                    sums[dr.GetName(i).ToString()] += double.Parse(dr[i].ToString());
                }
                if (dr.GetName(i).ToString().Equals(amt))
                    tranamt += double.Parse(dr[i].ToString());
            }
            trxn = trxn + 1;
        }

        //  Write total ....

        sw.WriteLine("<tr align=center>");
        for (i = 0; i < colcount - (sums.Count + 2); i++)
        {
            if (flag == "Y")
            {
                if (i == 2)
                    sw.WriteLine("<td><b>TOTAL:</td>");
                //else if (i == 3)
                //    sw.WriteLine("<td><b>" + trxn.ToString() + "</td>");
                else if (i == 21)
                    sw.WriteLine("<td class=text><b>" + String.Format("{0:0.00}", tranamt) + "</td>");
                else
                    sw.WriteLine("<td></td>");
            }
            else
            {
                if (i == 2)
                    sw.WriteLine("<td><b>TOTAL:</td>");
                //else if (i == 3)
                //    sw.WriteLine("<td><b>" + trxn.ToString() + "</td>");
                else
                    sw.WriteLine("<td></td>");
            }
        }
        foreach (KeyValuePair<string, double> obj in sums)
            sw.WriteLine("<td class=text><b>" + String.Format("{0:0.00}", obj.Value) + "</td>"); // write total of columns

        sw.WriteLine("<td></td><td></td></tr>");
        sw.WriteLine("</tr>");
        sw.WriteLine("<tr>");
        sw.WriteLine("<td colspan=2><b>End Of Report<b></td>");
        sw.WriteLine("<td colspan=" + (colcount - 2) + "></td>");
        sw.WriteLine("</tr>");
        sw.Close();
        sw.Dispose();
        GC.Collect();
        //code for image insert
        ImageWrite(FnameWithPath, IMG);
        // Enable_Security(FnameWithPath);

    }
    public void UtilityExcelWrite(string FnameWithPath, SqlDataReader dr, string type, string[] val, string IMG,string  Bankflag,string year)
    {
        StreamWriter sw;
        Int16 i, j, k = 0;
        int trxn = 0;
        var columns = new List<string>() { "TXN AMT", "5% CASH BACK OFFER (Cap of Rs 50 Per Month)", "CASH BACK OFFER paid by NPCI", "Credit to Bank", "Total Amount of Approved Transactions" };

        Dictionary<string, double> sums = new Dictionary<string, double>();
        if ((dr.HasRows == false))
        {
            return;
        }
        // sw = New StreamWriter(FnameWithPath)


        //Write Data
        sw = File.AppendText(FnameWithPath);
        // StreamWriter sw= File.AppendText(Server.MapPath("").ToString() + "\\test.txt")
        // sw.WriteLine("<html><head><style> <!-- td     { padding-top:1px; } .text {mso-style-parent:style0;mso-number-format:""\@"";} .number {mso-style-parent:style0;      mso-number-format:""\#\,\#\#0\.00\;\[Red\]\#\,\#\#0\.00"";}--> </style>")
        sw.WriteLine(@"<html><head><style> <!-- td     { padding-top:1px; } .text {mso-style-parent:style0;mso-number-format:""\@"";} .number {mso-style-parent:style0;      mso-number-format:General;}  .date{mso-style-parent:style0;mso-number-format:""\[ENG\]\[$-409\]d\\-mmm\\-yy\;\@"";}--> </style>");
        sw.WriteLine(@"<!--[if gte mso 9]><xml> <x:ExcelWorkbook>  <x:ExcelWorksheets>   <x:ExcelWorksheet>    <x:Name>Sheet1</x:Name>   <x:WorksheetOptions> <x:Selected/> <x:DisplayGridlines/> </x:WorksheetOptions> </x:ExcelWorksheet> </x:ExcelWorksheets> </x:ExcelWorkbook> </xml><![endif]--> </head><body><table border=1 bordercolor=ActiveBorder>");
        if ((type == "csv"))
        {

        }
        else
        {
            colcount = dr.FieldCount;//decide no of colums

            sw.WriteLine("<tr>");
            sw.WriteLine("<td colspan=2></td></tr>");
            for (i = 0; i < 9; i++)
            {
                sw.WriteLine("<tr>");
                sw.WriteLine("<td></td>");
                sw.WriteLine("<td></td>");
                sw.WriteLine("<td align=left><b>" + array[k] + ":</b></td>");
                sw.WriteLine("<td align=left class=text>" + val[k] + "</td>");
                if (k == 3 || k == 4)
                {
                    sw.WriteLine("<td align=left><b>(Transaction Date) </td>");
                    for (j = 0; j < colcount - 5; j++)
                        sw.WriteLine(("<td></td>"));
                }
                else
                {
                    for (j = 0; j < colcount - 4; j++)
                        sw.WriteLine(("<td></td>"));
                }
                sw.WriteLine("</tr>");
                k++;
            }
            sw.WriteLine("<tr>");
            for (i = 0; i < colcount; i++)
                sw.WriteLine("<td></td>");
            sw.WriteLine("</tr>");
            sw.WriteLine("<tr>");
            sw.WriteLine("<td colspan=" + colcount + " align=left style='margin-left:500px;'><b>Note: Amount is applicable only for Approved transactions.</b></td>");
            sw.WriteLine("</tr>");
            sw.WriteLine("<tr>");
            if (Bankflag == "Y")
                //sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8 align=center><b>Year:" + year + "</b></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 6) + " align=left style='margin-left:500px;' bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td>");
                sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8 align=center><b>Year:" + year + "</b></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 6) + " align=left style='margin-left:500px;' bgcolor=#D8D8D8><b>RuPay Transactions Details</b></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td>");
            else
                sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8 align=center><b>Year:" + year + "</b></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 6) + " align=left style='margin-left:500px;' bgcolor=#D8D8D8><b>RuPay Transactions Details</b></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td>");
         
            sw.WriteLine("</tr>");
            sw.WriteLine("<tr>");
            for (i = 0; (i <= (dr.FieldCount - 1)); i++)
            {
                sw.WriteLine(("<th bgcolor=#D8D8D8>" + dr.GetName(i)));

                if (columns.Contains(dr.GetName(i).ToString()))
                    sums.Add(dr.GetName(i).ToString(), 0);
            }
        }

        sw.WriteLine("<tr>");
        for (i = 0; i < colcount; i++)
            sw.WriteLine("<td bgcolor=#D8D8D8></td>");
        sw.WriteLine("</tr>");

        while (dr.Read())
        {
            sw.WriteLine("<tr bordercolor=ActiveBorder style=\'height:12.95pt;\'>");
            for (i = 0; (i <= (dr.FieldCount - 1)); i++)
            {
                //if (Information.IsNumeric(dr[i].ToString()) == true)
                //    sw.WriteLine(("<td bordercolor=ActiveBorder class=number align=center>" + dr[i]));
                //else
                sw.WriteLine(("<td bordercolor=ActiveBorder class=text align=center>" + dr[i]));

                if (columns.Contains(dr.GetName(i).ToString()))
                {
                    //double old = sums[dr.GetName(i).ToString()];
                    sums[dr.GetName(i).ToString()] += double.Parse(dr[i].ToString());
                }

            }
            trxn = trxn + 1;
        }

        //  Write total ....
        sw.WriteLine("<tr align=center>");
        for (i = 0; i < colcount - (sums.Count + 2); i++)
        {
            if (i == 2)
                sw.WriteLine("<td><b>TOTAL:</td>");
            //else if (i == 3)
            //    sw.WriteLine("<td><b>" + trxn.ToString() + "</td>");
            else
                sw.WriteLine("<td></td>");
        }
        foreach (KeyValuePair<string, double> obj in sums)
            sw.WriteLine("<td class=text><b>" + String.Format("{0:0.00}", obj.Value) + "</td>"); // write total of columns

        sw.WriteLine("<td></td><td></td></tr>");

        sw.WriteLine("<tr>");
        sw.WriteLine("<td colspan=2><b>End Of Report<b></td>");
        sw.WriteLine("<td colspan=" + (colcount - 2) + "></td>");
        sw.WriteLine("</tr>");
        sw.Close();
        sw.Dispose();
        GC.Collect();
        //code for image insert

        //var oXL = new Microsoft.Office.Interop.Excel.Application();

        //oXL.Visible = false;
        //oXL.DisplayAlerts = false;
        //Microsoft.Office.Interop.Excel.Workbook mWorkBook = oXL.Workbooks.Open(FnameWithPath, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
        //Microsoft.Office.Interop.Excel.Worksheet mWorkSheets = (Microsoft.Office.Interop.Excel.Worksheet)mWorkBook.Sheets[1];
        //mWorkSheets.Shapes.AddPicture(IMG, MsoTriState.msoFalse, MsoTriState.msoCTrue, 0, 0, 115, 16);
        //mWorkBook.SaveAs(FnameWithPath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
        //mWorkBook.Close(true);
        //oXL.Quit();
        //Marshal.ReleaseComObject(oXL);
        ImageWrite(FnameWithPath, IMG);
        // Enable_Security(FnameWithPath);

    }
    public void FuelExcelWrite(string FnameWithPath, SqlDataReader dr, string type, string[] val, string IMG,string  Bankflag,string year)
    {
        StreamWriter sw;
        Int16 i, j, k = 0;
        int trxn = 0;
        var columns = new List<string>() { "TXN AMT", "SURCHARGE AMT", "Zero Fuel Surcharge Amt (< 2000 = 0.75% & > 2000 = 1%)", "CASH BACK OFFER paid by NPCI (Max cap of 75 Per Month)", "Zero Fuel Surcharge Amt (Max Cap of 75 Per Month)", "Zero Fuel Surcharge - Credit to Bank (Max Cap of 75 Per Month)", "Total Amount of Approved Transactions" };
        Dictionary<string, double> sums = new Dictionary<string, double>();
        if ((dr.HasRows == false))
        {
            return;
        }
        // sw = New StreamWriter(FnameWithPath)


        //Write Data
        sw = File.AppendText(FnameWithPath);
        // StreamWriter sw= File.AppendText(Server.MapPath("").ToString() + "\\test.txt")
        // sw.WriteLine("<html><head><style> <!-- td     { padding-top:1px; } .text {mso-style-parent:style0;mso-number-format:""\@"";} .number {mso-style-parent:style0;      mso-number-format:""\#\,\#\#0\.00\;\[Red\]\#\,\#\#0\.00"";}--> </style>")
        sw.WriteLine(@"<html><head><style> <!-- td     { padding-top:1px; } .text {mso-style-parent:style0;mso-number-format:""\@"";} .number {mso-style-parent:style0;      mso-number-format:General;}  .date{mso-style-parent:style0;mso-number-format:""\[ENG\]\[$-409\]d\\-mmm\\-yy\;\@"";}--> </style>");
        sw.WriteLine(@"<!--[if gte mso 9]><xml> <x:ExcelWorkbook>  <x:ExcelWorksheets>   <x:ExcelWorksheet>    <x:Name>Sheet1</x:Name>   <x:WorksheetOptions> <x:Selected/> <x:DisplayGridlines/> </x:WorksheetOptions> </x:ExcelWorksheet> </x:ExcelWorksheets> </x:ExcelWorkbook> </xml><![endif]--> </head><body><table border=1 bordercolor=ActiveBorder>");
        if ((type == "csv"))
        {

        }
        else
        {
            colcount = dr.FieldCount;//decide no of colums

            sw.WriteLine("<tr>");
            sw.WriteLine("<td colspan=2></td></tr>");
            for (i = 0; i < 9; i++)
            {
                sw.WriteLine("<tr>");
                sw.WriteLine("<td></td>");
                sw.WriteLine("<td></td>");
                sw.WriteLine("<td align=left><b>" + array[k] + ":</b></td>");
                sw.WriteLine("<td align=left class=text>" + val[k] + "</td>");
                if (k == 3 || k == 4)
                {
                    sw.WriteLine("<td align=left><b>(Transaction Date) </td>");
                    for (j = 0; j < colcount - 5; j++)
                        sw.WriteLine(("<td></td>"));
                }
                else
                {
                    for (j = 0; j < colcount - 4; j++)
                        sw.WriteLine(("<td></td>"));
                }
                sw.WriteLine("</tr>");
                k++;
            }
            sw.WriteLine("<tr>");
            for (i = 0; i < colcount; i++)
                sw.WriteLine("<td></td>");
            sw.WriteLine("</tr>");
            sw.WriteLine("<tr>");
            sw.WriteLine("<td colspan=" + colcount + " align=left style='margin-left:500px;'><b>Note: Amount is applicable only for Approved transactions.</b></td>");
            sw.WriteLine("</tr>");
            sw.WriteLine("<tr>");
            if (Bankflag == "Y")
                //sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8 align=center><b>Year:" + year + "</b></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 6) + " align=left style='margin-left:500px;' bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td>");
                sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8 align=center><b>Year:" + year + "</b></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 6) + " align=left style='margin-left:500px;' bgcolor=#D8D8D8><b>RuPay Transactions Details</b></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td>");
            else
                sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8 align=center><b>Year:" + year + "</b></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 6) + " align=left style='margin-left:500px;' bgcolor=#D8D8D8><b>RuPay Transactions Details</b></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td>");
              
            sw.WriteLine("</tr>");
            sw.WriteLine("<tr>");
            for (i = 0; (i <= (dr.FieldCount - 1)); i++)
            {
                sw.WriteLine(("<th bgcolor=#D8D8D8>" + dr.GetName(i)));

                if (columns.Contains(dr.GetName(i).ToString()))
                    sums.Add(dr.GetName(i).ToString(), 0);
            }
        }

        sw.WriteLine("<tr>");
        for (i = 0; i < colcount; i++)
            sw.WriteLine("<td bgcolor=#D8D8D8></td>");
        sw.WriteLine("</tr>");

        while (dr.Read())
        {
            sw.WriteLine("<tr bordercolor=ActiveBorder style=\'height:12.95pt;\'>");
            for (i = 0; (i <= (dr.FieldCount - 1)); i++)
            {
                //if (Information.IsNumeric(dr[i].ToString()) == true)
                //    sw.WriteLine(("<td bordercolor=ActiveBorder class=number align=center>" + dr[i]));
                //else
                sw.WriteLine(("<td bordercolor=ActiveBorder class=text align=center>" + dr[i]));
                if (columns.Contains(dr.GetName(i).ToString()))
                {
                    //double old = sums[dr.GetName(i).ToString()];
                    sums[dr.GetName(i).ToString()] += double.Parse(dr[i].ToString());
                }

            }
            trxn = trxn + 1;
        }

        //  Write total ....
        sw.WriteLine("<tr align=center>");
        for (i = 0; i < colcount - (sums.Count + 2); i++)
        {
            if (i == 2)
                sw.WriteLine("<td><b>TOTAL:</td>");
            //else if (i == 3)
            //    sw.WriteLine("<td><b>" + trxn.ToString() + "</td>");
            else
                sw.WriteLine("<td></td>");
        }
        foreach (KeyValuePair<string, double> obj in sums)
            sw.WriteLine("<td class=text><b>" + String.Format("{0:0.00}", obj.Value) + "</td>"); // write total of columns
        sw.WriteLine("<td></td><td></td></tr>");
        sw.WriteLine("<tr>");
        sw.WriteLine("<td colspan=2><b>End Of Report<b></td>");
        sw.WriteLine("<td colspan=" + (colcount - 2) + "></td>");
        sw.WriteLine("</tr>");
        sw.Close();
        sw.Dispose();
        GC.Collect();
        ImageWrite(FnameWithPath, IMG);
    }
    public void IRCTCExcelWrite(string FnameWithPath, SqlDataReader dr, string type, string[] val, string IMG, string Bankflag, string year)
    {
        StreamWriter sw;
        Int16 i, j, k = 0;
        int trxn = 0;
        var columns = new List<string>() { "TXN AMT", "Per Month Cap Amt - 25", "CASH BACK OFFER paid by NPCI", "CASH BACK OFFER to Member Bank", "Cash Back of Rs 25 - Credit to Bank", "Total Amount of Approved Transactions" };
        Dictionary<string, double> sums = new Dictionary<string, double>();
        if ((dr.HasRows == false))
        {
            return;
        }
        // sw = New StreamWriter(FnameWithPath)


        //Write Data
        sw = File.AppendText(FnameWithPath);
        // StreamWriter sw= File.AppendText(Server.MapPath("").ToString() + "\\test.txt")
        // sw.WriteLine("<html><head><style> <!-- td     { padding-top:1px; } .text {mso-style-parent:style0;mso-number-format:""\@"";} .number {mso-style-parent:style0;      mso-number-format:""\#\,\#\#0\.00\;\[Red\]\#\,\#\#0\.00"";}--> </style>")
        sw.WriteLine(@"<html><head><style> <!-- td     { padding-top:1px; } .text {mso-style-parent:style0;mso-number-format:""\@"";} .number {mso-style-parent:style0;      mso-number-format:General;}  .date{mso-style-parent:style0;mso-number-format:""\[ENG\]\[$-409\]d\\-mmm\\-yy\;\@"";}--> </style>");
        sw.WriteLine(@"<!--[if gte mso 9]><xml> <x:ExcelWorkbook>  <x:ExcelWorksheets>   <x:ExcelWorksheet>    <x:Name>Sheet1</x:Name>   <x:WorksheetOptions> <x:Selected/> <x:DisplayGridlines/> </x:WorksheetOptions> </x:ExcelWorksheet> </x:ExcelWorksheets> </x:ExcelWorkbook> </xml><![endif]--> </head><body><table border=1 bordercolor=ActiveBorder>");
        if ((type == "csv"))
        {

        }
        else
        {
            colcount = dr.FieldCount;//decide no of colums

            sw.WriteLine("<tr>");
            sw.WriteLine("<td colspan=2></td></tr>");
            for (i = 0; i < 9; i++)
            {
                sw.WriteLine("<tr>");
                sw.WriteLine("<td></td>");
                sw.WriteLine("<td></td>");
                sw.WriteLine("<td align=left><b>" + array[k] + ":</b></td>");
                sw.WriteLine("<td align=left class=text>" + val[k] + "</td>");
                //To add Settlement Label in Report
                if (k == 3 || k == 4)
                {
                    sw.WriteLine("<td align=left><b>(Transaction Date) </td>");
                    for (j = 0; j < colcount - 5; j++)
                        sw.WriteLine(("<td></td>"));
                }
                else
                {
                    for (j = 0; j < colcount - 4; j++)
                        sw.WriteLine(("<td></td>"));
                }
                sw.WriteLine("</tr>");
                k++;
            }
            sw.WriteLine("<tr>");
            for (i = 0; i < colcount; i++)
                sw.WriteLine("<td></td>");
            sw.WriteLine("</tr>");
            sw.WriteLine("<tr>");
            sw.WriteLine("<td colspan=" + colcount + " align=left style='margin-left:500px;'><b>Note: Amount is applicable only for Approved transactions.</b></td>");
            sw.WriteLine("</tr>");
            sw.WriteLine("<tr>");
            if (Bankflag == "Y")
                sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8 align=center><b>Year:" + year + "</b></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 6) + " align=left style='margin-left:500px;' bgcolor=#D8D8D8><b>RuPay Transactions Details</b></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td>");
                //sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8 align=center><b>Year:" + year + "</b></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 6) + " align=left style='margin-left:500px;' bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td>");
            else
                sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8 align=center><b>Year:" + year + "</b></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 6) + " align=left style='margin-left:500px;' bgcolor=#D8D8D8><b>RuPay Transactions Details</b></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td>");
     
         
            sw.WriteLine("</tr>");
            sw.WriteLine("<tr>");
            for (i = 0; (i <= (dr.FieldCount - 1)); i++)
            {
                sw.WriteLine(("<th bgcolor=#D8D8D8>" + dr.GetName(i)));
                if (columns.Contains(dr.GetName(i).ToString()))
                    sums.Add(dr.GetName(i).ToString(), 0);
            }
        }

        sw.WriteLine("<tr>");
        for (i = 0; i < colcount; i++)
            sw.WriteLine("<td bgcolor=#D8D8D8></td>");
        sw.WriteLine("</tr>");

        while (dr.Read())
        {
            sw.WriteLine("<tr bordercolor=ActiveBorder style=\'height:12.95pt;\'>");
            for (i = 0; (i <= (dr.FieldCount - 1)); i++)
            {
                //if (Information.IsNumeric(dr[i].ToString()) == true)
                //    sw.WriteLine(("<td bordercolor=ActiveBorder class=number align=center>" + dr[i]));
                //else
                sw.WriteLine(("<td bordercolor=ActiveBorder class=text align=center>" + dr[i]));

                //Calculate Total of columns
                if (columns.Contains(dr.GetName(i).ToString()))
                {
                    //double old = sums[dr.GetName(i).ToString()];
                    sums[dr.GetName(i).ToString()] += double.Parse(dr[i].ToString());
                }

            }
            trxn = trxn + 1;
        }

        //  Write total ....
        sw.WriteLine("<tr align=center>");
        for (i = 0; i < colcount - (sums.Count + 2); i++)
        {
            if (i == 1)
                sw.WriteLine("<td><b>TOTAL:</td>");
            //else if (i == 3)
            //    sw.WriteLine("<td><b>" + trxn.ToString() + "</td>");
            else
                sw.WriteLine("<td></td>");
        }
        foreach (KeyValuePair<string, double> obj in sums)
            sw.WriteLine("<td class=text><b>" + String.Format("{0:0.00}", obj.Value) + "</td>"); // write total of columns
        sw.WriteLine("<td></td><td></td></tr>");

        sw.WriteLine("<tr>");
        sw.WriteLine("<td colspan=2><b>End Of Report<b></td>");
        sw.WriteLine("<td colspan=" + (colcount - 2) + "></td>");
        sw.WriteLine("</tr>");
        sw.Close();
        sw.Dispose();
        GC.Collect();
        ImageWrite(FnameWithPath, IMG);
        //// Enable_Security(FnameWithPath);

    }
    public void MovieExcelWrite(string FnameWithPath, SqlDataReader dr, string type, string[] val, string IMG, string Bankflag, string year)
    {
        StreamWriter sw;
        Int16 i, j, k = 0;
        int trxn = 0;
        var columns = new List<string>() { "TXN AMT (Min 75)", "10% on Txn amt (Capping 50 per txn)", "CASH BACK OFFER paid by NPCI", "CASH BACK OFFER to Member Bank", "CASH BACK OFFER to Merchant", "Cash Back of Rs 25 - Credit to Bank", "Per Month Cap Amt - 25", "Total Amount of Approved Transactions", "Of 25% - 10% CB by NPCI", "Of 25% - 10% CB paid to Merchant", "25% on Txn amt", "Of 25% - 10% CB to Merchant" };                                                                                                                                                                                                                                                                                                                                                                                                       
        Dictionary<string, double> sums = new Dictionary<string, double>();
        if ((dr.HasRows == false))
        {
            return;
        }
        // sw = New StreamWriter(FnameWithPath)


        //Write Data
        sw = File.AppendText(FnameWithPath);
        // StreamWriter sw= File.AppendText(Server.MapPath("").ToString() + "\\test.txt")
        // sw.WriteLine("<html><head><style> <!-- td     { padding-top:1px; } .text {mso-style-parent:style0;mso-number-format:""\@"";} .number {mso-style-parent:style0;      mso-number-format:""\#\,\#\#0\.00\;\[Red\]\#\,\#\#0\.00"";}--> </style>")

        sw.WriteLine(@"<html><head><style> <!-- td     { padding-top:1px; } .text {mso-style-parent:style0;mso-number-format:""\@"";} .number {mso-style-parent:style0;      mso-number-format:General;}  .date{mso-style-parent:style0;mso-number-format:""\[ENG\]\[$-409\]d\\-mmm\\-yy\;\@"";}--> </style>");
        sw.WriteLine(@"<!--[if gte mso 9]><xml> <x:ExcelWorkbook>  <x:ExcelWorksheets>   <x:ExcelWorksheet>    <x:Name>Sheet1</x:Name>   <x:WorksheetOptions> <x:Selected/> <x:DisplayGridlines/> </x:WorksheetOptions> </x:ExcelWorksheet> </x:ExcelWorksheets> </x:ExcelWorkbook> </xml><![endif]--> </head><body><table border=1 bordercolor=ActiveBorder>");

        if ((type == "csv"))
        {

        }
        else
        {
            colcount = dr.FieldCount;//decide no of colums

            sw.WriteLine("<tr>");
            sw.WriteLine("<td colspan=2></td></tr>");
            for (i = 0; i < 9; i++)
            {
                sw.WriteLine("<tr>");
                sw.WriteLine("<td></td>");
                sw.WriteLine("<td></td>");
                sw.WriteLine("<td align=left><b>" + array[k] + ":</b></td>");
                sw.WriteLine("<td align=left class=text>" + val[k] + "</td>");
                if (k == 3 || k == 4)
                {
                    sw.WriteLine("<td align=left><b>(Transaction Date) </td>");
                    for (j = 0; j < colcount - 5; j++)
                        sw.WriteLine(("<td></td>"));
                }
                else
                {
                    for (j = 0; j < colcount - 4; j++)
                        sw.WriteLine(("<td></td>"));
                }
                sw.WriteLine("</tr>");
                k++;
            }
            sw.WriteLine("<tr>");
            for (i = 0; i < colcount; i++)
                sw.WriteLine("<td></td>");
            sw.WriteLine("</tr>");
            sw.WriteLine("<tr>");
            sw.WriteLine("<td colspan=" + colcount + " align=left style='margin-left:500px;'><b>Note: Amount is applicable only for Approved transactions.</b></td>");
            sw.WriteLine("</tr>");
            sw.WriteLine("<tr>");
            if (Bankflag == "Y")
               // sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8 align=center><b>Year:" + year + "</b></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 6) + " align=left style='margin-left:500px;' bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td>");
                sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8 align=center><b>Year:" + year + "</b></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 6) + " align=left style='margin-left:500px;' bgcolor=#D8D8D8><b>RuPay Transactions Details</b></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td>");
            else
                sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8 align=center><b>Year:" + year + "</b></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 6) + " align=left style='margin-left:500px;' bgcolor=#D8D8D8><b>RuPay Transactions Details</b></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td>");
     
            sw.WriteLine("</tr>");
            sw.WriteLine("<tr>");
            for (i = 0; (i <= (dr.FieldCount - 1)); i++)
            {
                sw.WriteLine(("<th bgcolor=#D8D8D8>" + dr.GetName(i)));
                if (columns.Contains(dr.GetName(i).ToString()))
                    sums.Add(dr.GetName(i).ToString(), 0);
            }
        }

        sw.WriteLine("<tr>");
        for (i = 0; i < colcount; i++)
            sw.WriteLine("<td bgcolor=#D8D8D8></td>");
        sw.WriteLine("</tr>");

        while (dr.Read())
        {
            sw.WriteLine("<tr bordercolor=ActiveBorder style=\'height:12.95pt;\'>");
            for (i = 0; (i <= (dr.FieldCount - 1)); i++)
            {
                //if (Information.IsNumeric(dr[i].ToString()) == true)
                //    sw.WriteLine(("<td bordercolor=ActiveBorder class=number align=center>" + dr[i]));
                //else
                sw.WriteLine(("<td bordercolor=ActiveBorder class=text align=center>" + dr[i]));
                if (columns.Contains(dr.GetName(i).ToString()))
                {
                    //double old = sums[dr.GetName(i).ToString()];
                    sums[dr.GetName(i).ToString()] += double.Parse(dr[i].ToString());
                }
            }
            trxn = trxn + 1;
        }

        //  Write total ....
        sw.WriteLine("<tr align=center>");
        for (i = 0; i < colcount - (sums.Count + 2); i++)
        {
            if (i == 1)
                sw.WriteLine("<td><b>TOTAL:</td>");
            //else if (i == 2)
            //    sw.WriteLine("<td><b>" + trxn.ToString() + "</td>");
            else
                sw.WriteLine("<td></td>");
        }
        foreach (KeyValuePair<string, double> obj in sums)
            sw.WriteLine("<td class=text><b>" + String.Format("{0:0.00}", obj.Value) + "</td>");
        sw.WriteLine("<td></td><td></td></tr>");
        sw.WriteLine("<tr>");
        sw.WriteLine("<td colspan=2><b>End Of Report<b></td>");
        sw.WriteLine("<td colspan=" + (colcount - 2) + "></td>");
        sw.WriteLine("</tr>");
        sw.Close();
        sw.Dispose();
        GC.Collect();
        ImageWrite(FnameWithPath, IMG);
        // Enable_Security(FnameWithPath);

    }
    public void CCDDiscountExcelWrite(string FnameWithPath, SqlDataReader dr, string type, string[] val, string IMG,string  Bankflag,string year)
    {
        StreamWriter sw;
        Int16 i, j, k = 0;
        int trxn = 0;
        var columns = new List<string>() { "TXN AMT(Min 300 & Above)", "15% on Txn amt", "15% on Txn amt to Merchant", "CASH BACK OFFER paid by NPCI", "CASH BACK OFFER to Member Bank", "15% on Txn amt to Merchant", "25% on Txn amt", "Of 25% - 10% CB by NPCI", "Of 25% - 10% CB paid to Merchant", "Total Amount of Approved Transactions" };
        Dictionary<string, double> sums = new Dictionary<string, double>();

        if ((dr.HasRows == false))
        {
            return;
        }
        // sw = New StreamWriter(FnameWithPath)


        //Write Data
        sw = File.AppendText(FnameWithPath);
        // StreamWriter sw= File.AppendText(Server.MapPath("").ToString() + "\\test.txt")
        // sw.WriteLine("<html><head><style> <!-- td     { padding-top:1px; } .text {mso-style-parent:style0;mso-number-format:""\@"";} .number {mso-style-parent:style0;      mso-number-format:""\#\,\#\#0\.00\;\[Red\]\#\,\#\#0\.00"";}--> </style>")
        sw.WriteLine(@"<html><head><style> <!-- td     { padding-top:1px; } .text {mso-style-parent:style0;mso-number-format:""\@"";} .number {mso-style-parent:style0;      mso-number-format:General;}  .date{mso-style-parent:style0;mso-number-format:""\[ENG\]\[$-409\]d\\-mmm\\-yy\;\@"";}--> </style>");
        sw.WriteLine(@"<!--[if gte mso 9]><xml> <x:ExcelWorkbook>  <x:ExcelWorksheets>   <x:ExcelWorksheet>    <x:Name>Sheet1</x:Name>   <x:WorksheetOptions> <x:Selected/> <x:DisplayGridlines/> </x:WorksheetOptions> </x:ExcelWorksheet> </x:ExcelWorksheets> </x:ExcelWorkbook> </xml><![endif]--> </head><body><table border=1 bordercolor=ActiveBorder>");
        if ((type == "csv"))
        {

        }
        else
        {
            colcount = dr.FieldCount;//decide no of colums

            sw.WriteLine("<tr>");
            sw.WriteLine("<td colspan=2></td></tr>");
            for (i = 0; i < 9; i++)
            {
                sw.WriteLine("<tr>");
                sw.WriteLine("<td></td>");
                sw.WriteLine("<td></td>");
                sw.WriteLine("<td align=left><b>" + array[k] + ":</b></td>");
                sw.WriteLine("<td align=left class=text>" + val[k] + "</td>");
                if (k == 3 || k == 4)
                {
                    sw.WriteLine("<td align=left><b>(Transaction Date) </td>");
                    for (j = 0; j < colcount - 5; j++)
                        sw.WriteLine(("<td></td>"));
                }
                else
                {
                    for (j = 0; j < colcount - 4; j++)
                        sw.WriteLine(("<td></td>"));
                }
                sw.WriteLine("</tr>");
                k++;
            }
            sw.WriteLine("<tr>");
            for (i = 0; i < colcount; i++)
                sw.WriteLine("<td></td>");
            sw.WriteLine("</tr>");
            sw.WriteLine("<tr>");
            sw.WriteLine("<td colspan=" + colcount + " align=left style='margin-left:500px;'><b>Note: Amount is applicable only for Approved transactions.</b></td>");
            sw.WriteLine("</tr>");
            sw.WriteLine("<tr>");
            if (Bankflag == "Y")
                //sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8 align=center><b>Year:" + year + "</b></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 6) + " align=left style='margin-left:500px;' bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td>");
                sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8 align=center><b>Year:" + year + "</b></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 6) + " align=left style='margin-left:500px;' bgcolor=#D8D8D8><b>RuPay Transactions Details</b></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td>");
            else
                sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8 align=center><b>Year:" + year + "</b></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 6) + " align=left style='margin-left:500px;' bgcolor=#D8D8D8><b>RuPay Transactions Details</b></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td>");
              
            sw.WriteLine("</tr>");
            sw.WriteLine("<tr>");
            for (i = 0; (i <= (dr.FieldCount - 1)); i++)
            {
                sw.WriteLine(("<th bgcolor=#D8D8D8>" + dr.GetName(i)));
                if (columns.Contains(dr.GetName(i).ToString()))
                    sums.Add(dr.GetName(i).ToString(), 0);
            }
        }

        sw.WriteLine("<tr>");
        for (i = 0; i < colcount; i++)
            sw.WriteLine("<td bgcolor=#D8D8D8></td>");
        sw.WriteLine("</tr>");

        while (dr.Read())
        {
            sw.WriteLine("<tr bordercolor=ActiveBorder style=\'height:12.95pt;\'>");
            for (i = 0; (i <= (dr.FieldCount - 1)); i++)
            {
                //if (Information.IsNumeric(dr[i].ToString()) == true)
                //    sw.WriteLine(("<td bordercolor=ActiveBorder class=number align=center>" + dr[i]));
                //else
                sw.WriteLine(("<td bordercolor=ActiveBorder class=text align=center>" + dr[i]));
                if (columns.Contains(dr.GetName(i).ToString()))
                {
                    //double old = sums[dr.GetName(i).ToString()];
                    sums[dr.GetName(i).ToString()] += double.Parse(dr[i].ToString());
                }
            }
            trxn = trxn + 1;
        }

        //  Write total ....
        sw.WriteLine("<tr align=center>");
        for (i = 0; i < colcount - (sums.Count + 2); i++)
        {
            if (i == 1)
                sw.WriteLine("<td><b>TOTAL:</td>");
            //else if (i == 2)
            //    sw.WriteLine("<td><b>" + trxn.ToString() + "</td>");
            else
                sw.WriteLine("<td></td>");
        }
        foreach (KeyValuePair<string, double> obj in sums)
            sw.WriteLine("<td class=text><b>" + String.Format("{0:0.00}", obj.Value) + "</td>");
        sw.WriteLine("<td></td><td></td></tr>");
        sw.WriteLine("<tr>");
        sw.WriteLine("<td colspan=2><b>End Of Report<b></td>");
        sw.WriteLine("<td colspan=" + (colcount - 2) + "></td>");
        sw.WriteLine("</tr>");
        sw.Close();
        sw.Dispose();
        GC.Collect();

        ImageWrite(FnameWithPath, IMG);
        // Enable_Security(FnameWithPath);

    }
    public void CCDExcelWrite(string FnameWithPath, SqlDataReader dr, string type, string[] val, string IMG, string Bankflag, string year)
    {
        StreamWriter sw;
        Int16 i, j, k = 0;
        int trxn = 0;
        string amt = "Transaction Amount";
        double tranamt = 0.00;
        string flag = "N";//check whether tran amount column exists or not
        var columns = new List<string>() { "Amount to be paid by NPCI", "Amount to be paid to Vendor/Merchant", "Total Amount of Approved Transactions", "TXN AMT" };
        Dictionary<string, double> sums = new Dictionary<string, double>();

        if ((dr.HasRows == false))
        {
            return;
        }
        // sw = New StreamWriter(FnameWithPath)


        //Write Data
        sw = File.AppendText(FnameWithPath);
        // StreamWriter sw= File.AppendText(Server.MapPath("").ToString() + "\\test.txt")
        // sw.WriteLine("<html><head><style> <!-- td     { padding-top:1px; } .text {mso-style-parent:style0;mso-number-format:""\@"";} .number {mso-style-parent:style0;      mso-number-format:""\#\,\#\#0\.00\;\[Red\]\#\,\#\#0\.00"";}--> </style>")
        sw.WriteLine(@"<html><head><style> <!-- td     { padding-top:1px; } .text {mso-style-parent:style0;mso-number-format:""\@"";} .number {mso-style-parent:style0;      mso-number-format:General;}  .date{mso-style-parent:style0;mso-number-format:""\[ENG\]\[$-409\]d\\-mmm\\-yy\;\@"";}--> </style>");
        sw.WriteLine(@"<!--[if gte mso 9]><xml> <x:ExcelWorkbook>  <x:ExcelWorksheets>   <x:ExcelWorksheet>    <x:Name>Sheet1</x:Name>   <x:WorksheetOptions> <x:Selected/> <x:DisplayGridlines/> </x:WorksheetOptions> </x:ExcelWorksheet> </x:ExcelWorksheets> </x:ExcelWorkbook> </xml><![endif]--> </head><body><table border=1 bordercolor=ActiveBorder>");
        if ((type == "csv"))
        {

        }
        else
        {
            colcount = dr.FieldCount;//count no of colums

            sw.WriteLine("<tr>");
            sw.WriteLine("<td colspan=2></td></tr>");
            for (i = 0; i < 9; i++)
            {
                sw.WriteLine("<tr>");
                sw.WriteLine("<td></td>");
                sw.WriteLine("<td></td>");
                sw.WriteLine("<td align=left><b>" + array[k] + ":</b></td>");
                sw.WriteLine("<td align=left class=text>" + val[k] + "</td>");
                if (k == 3 || k == 4)
                {
                    sw.WriteLine("<td align=left><b>(Transaction Date) </td>");
                    for (j = 0; j < colcount - 5; j++)
                        sw.WriteLine(("<td></td>"));
                }
                else
                {
                    for (j = 0; j < colcount - 4; j++)
                        sw.WriteLine(("<td></td>"));
                }
                sw.WriteLine("</tr>");
                k++;
            }
            sw.WriteLine("<tr>");
            for (i = 0; i < colcount; i++)
                sw.WriteLine("<td></td>");
            sw.WriteLine("</tr>");
            sw.WriteLine("<tr>");
            sw.WriteLine("<td colspan=" + colcount + " align=left style='margin-left:500px;'><b>Note: Amount is applicable only for Approved transactions.</b></td>");
            sw.WriteLine("</tr>");
            sw.WriteLine("<tr>");
            if (Bankflag == "Y")
                //sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8 align=center><b>Year:" + year + "</b></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 6) + " align=left style='margin-left:500px;' bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td>");
                sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8 align=center><b>Year:" + year + "</b></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 6) + " align=left style='margin-left:500px;' bgcolor=#D8D8D8><b>RuPay Transactions Details</b></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td>");
            else
                sw.WriteLine("<td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8 align=center><b>Year:" + year + "</b></td><td bgcolor=#D8D8D8></td><td colspan=" + (colcount - 6) + " align=left style='margin-left:500px;' bgcolor=#D8D8D8><b>RuPay Transactions Details</b></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td><td bgcolor=#D8D8D8></td>");
          
            sw.WriteLine("</tr>");
            sw.WriteLine("<tr>");
            for (i = 0; (i <= (dr.FieldCount - 1)); i++)
            {
                sw.WriteLine(("<th bgcolor=#D8D8D8>" + dr.GetName(i)));
                if (columns.Contains(dr.GetName(i).ToString()))
                    sums.Add(dr.GetName(i).ToString(), 0);
                if (dr.GetName(i).ToString().Equals(amt))
                    flag = "Y";
            }
        }

        sw.WriteLine("<tr>");
        for (i = 0; i < colcount; i++)
            sw.WriteLine("<td bgcolor=#D8D8D8></td>");
        sw.WriteLine("</tr>");

        while (dr.Read())
        {
            sw.WriteLine("<tr bordercolor=ActiveBorder style=\'height:12.95pt;\'>");
            for (i = 0; (i <= (dr.FieldCount - 1)); i++)
            {
                //if (Information.IsNumeric(dr[i].ToString()) == true)
                //    sw.WriteLine(("<td bordercolor=ActiveBorder class=number align=center>" + dr[i]));
                //else
                sw.WriteLine(("<td bordercolor=ActiveBorder class=text align=center>" + dr[i]));
                if (columns.Contains(dr.GetName(i).ToString()))
                {
                    //double old = sums[dr.GetName(i).ToString()];
                    sums[dr.GetName(i).ToString()] += double.Parse(dr[i].ToString());
                }
                if (dr.GetName(i).ToString().Equals(amt))
                    tranamt += double.Parse(dr[i].ToString());
            }
            trxn = trxn + 1;
        }
        //write Total
        sw.WriteLine("<tr align=center>");
        for (i = 0; i < colcount - (sums.Count + 2); i++)
        {
            if (flag == "Y")
            {
                if (i == 2)
                    sw.WriteLine("<td><b>TOTAL:</td>");
                //else if (i == 3)
                //    sw.WriteLine("<td><b>" + trxn.ToString() + "</td>");
                else if (i == 15)
                    sw.WriteLine("<td class=text><b>" + String.Format("{0:0.00}", tranamt) + "</td>");
                else
                    sw.WriteLine("<td></td>");
            }
            else
            {
                if (i == 2)
                    sw.WriteLine("<td><b>TOTAL:</td>");
                //else if (i == 3)
                //    sw.WriteLine("<td><b>" + trxn.ToString() + "</td>");
                else
                    sw.WriteLine("<td></td>");
            }
        }
        foreach (KeyValuePair<string, double> obj in sums)
            sw.WriteLine("<td class=text><b>" + String.Format("{0:0.00}", obj.Value) + "</td>"); // write total of columns

        sw.WriteLine("<td></td><td></td></tr>");
        sw.WriteLine("</tr>");
        sw.WriteLine("<tr>");
        sw.WriteLine("<td colspan=2><b>End Of Report<b></td>");
        sw.WriteLine("<td colspan=" + (colcount - 2) + "></td>");
        sw.WriteLine("</tr>");
        sw.Close();
        sw.Dispose();
        GC.Collect();
        //code for image insert

        ImageWrite(FnameWithPath, IMG);
        // Enable_Security(FnameWithPath);

    }
    private void Enable_Security(string s)
    {
        try
        {
            object misValue = System.Reflection.Missing.Value;
            //oexcel = CreateObject("Excel.Application");
            oexcel = new Microsoft.Office.Interop.Excel.Application();
            oexcel.Application.DisplayAlerts = false;
            string password = "ISG";
            obook = oexcel.Workbooks.Open(s);
            obook.SaveAs(s, password);
            osheet = null;
            obook.Close();
            obook = null;
            oexcel.Quit();
            oexcel = null;
        }
        catch (Exception ex)
        {
            return;
        }
        finally
        {
            Process();
        }
    }
    /// <summary>
    /// Close excel process
    /// </summary>
    private void Process()
    {
        //Process process;

        Process[] process1 = System.Diagnostics.Process.GetProcesses();
        foreach (Process process in process1)
        {
            if ((process.ProcessName == "EXCEL"))
            {
                if ((process.HasExited == false))
                {
                    process.Kill();
                }
            }
        }
    }
    private int Search(int val, params string[] ar)
    {
        // string i;
        foreach (string i in ar)
        {
            if (((val.ToString() == i.Substring(1)) && (i.Substring(0, 1) == "T")))
            {
                return 1;

            }
            if (((val.ToString() == i.Substring(1)) && (i.Substring(0, 1) == "N")))
            {
                return 2;

            }
        }
        return 0;
    }
    /// <summary>
    ///  code for image insert
    /// </summary>
    /// <param name="path"></param>
    /// <param name="img"></param>
    public void ImageWrite(string path, string img)
    {
        //image insert in excel
        var oXL = new Microsoft.Office.Interop.Excel.Application();
        oXL.Visible = false;
        oXL.DisplayAlerts = false;
        Microsoft.Office.Interop.Excel.Workbook mWorkBook = oXL.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
        Microsoft.Office.Interop.Excel.Worksheet mWorkSheets = (Microsoft.Office.Interop.Excel.Worksheet)mWorkBook.Sheets[1];
        mWorkSheets.Shapes.AddPicture(img, MsoTriState.msoFalse, MsoTriState.msoCTrue, 0, 0, 115, 16);
        mWorkBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
        mWorkBook.Close(true);
        oXL.Quit();
        Marshal.ReleaseComObject(oXL);
    }
    public void ImageWrite1(string path, string img)
    {
        path.Replace(@"\\",@"\");
        Microsoft.Office.Interop.Excel.Application oXL = new Microsoft.Office.Interop.Excel.Application();
        oXL.Visible = false;
        oXL.DisplayAlerts = false;
        Microsoft.Office.Interop.Excel.Workbook mWorkBook = oXL.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
        Microsoft.Office.Interop.Excel.Worksheet mWorkSheets = (Microsoft.Office.Interop.Excel.Worksheet)mWorkBook.Sheets[1];
        mWorkSheets.Shapes.AddPicture(img, MsoTriState.msoFalse, MsoTriState.msoCTrue, 0, 0, 115, 16);
        Microsoft.Office.Interop.Excel.Worksheet mWorkSheets1 = (Microsoft.Office.Interop.Excel.Worksheet)mWorkBook.Sheets[2];
        mWorkSheets1.Shapes.AddPicture(img, MsoTriState.msoFalse, MsoTriState.msoCTrue, 0, 0, 115, 16);
        Microsoft.Office.Interop.Excel.Worksheet mWorkSheets2 = (Microsoft.Office.Interop.Excel.Worksheet)mWorkBook.Sheets[3];
        mWorkSheets2.Shapes.AddPicture(img, MsoTriState.msoFalse, MsoTriState.msoCTrue, 0, 0, 115, 16);
        mWorkBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
        mWorkBook.Close(true);
        oXL.Quit();
        Marshal.ReleaseComObject(oXL);
        oXL = null;
    }
    public void Multisheet(string FnameWithPath, DataSet Data_Set, string[] val, string IMG)
    {
        string[] SheetName = new string[3] { "Not Applicable For Offer", "Not Found in RGCS", "Not Found in Vendor File" };
        var columns = new List<string>() { "Access Fees to be paid by NPCI(Fees To be applied as per the Lounge Rate List)", "Total Amount of Approved Transactions", "TXN AMT", "Amount to be paid by NPCI", "CASH BACK OFFER paid by NPCI", "25% on Txn amt", "Of 25% - 10% CB paid to Merchant", "10% on Txn amt (Capping 50 per txn)", "Per Month Cap Amt - 25", "15% on Txn amt", "10% on Txn amt", "Of 25% - 10% CB by NPCI", "TXN AMT (Min 75)", "Of 25% - 10% CB by NPCI" };
        int count = 0;
        for (int i = 0; i < Data_Set.Tables.Count; i++)
        {
            if (Data_Set.Tables[i].Rows.Count == 0)
                count++;
        }
        if (count == Data_Set.Tables.Count)
            return;
        StringBuilder excelStr = new StringBuilder();
        int cnt_row, sht_cnt, c, colcount;
        Dictionary<String, double> sums;
        excelStr.Append(("<?xml version=\"1.0\"?>" + "\r\n"));
        excelStr.Append(("<?mso-application progid=\"Excel.Sheet\"?>" + "\r\n"));
        excelStr.Append(("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"" + "\r\n"));
        excelStr.Append(("xmlns:o=\"urn:schemas-microsoft-com:office:office\"" + "\r\n"));
        excelStr.Append(("xmlns:x=\"urn:schemas-microsoft-com:office:excel\"" + "\r\n"));
        excelStr.Append(("xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"" + "\r\n"));
        excelStr.Append(("xmlns:html=\"http://www.w3.org/TR/REC-html40\">" + "\r\n"));
        excelStr.Append("<Styles>");
        excelStr.Append("<Style ss:ID=\"N0\"> <NumberFormat ss:Format=\"Fixed\"/> </Style>");
        excelStr.Append("<Style ss:ID=\"T0\"> <NumberFormat ss:Format=\"@\"/> </Style>");
        excelStr.Append("<Style ss:ID=\"N1\"> <NumberFormat ss:Format=\"Fixed\"/> </Style>");
        excelStr.Append("<Style ss:ID=\"T1\"> <NumberFormat ss:Format=\"@\"/> </Style>");

        excelStr.Append("<Style ss:ID=\"s16\"><Borders><Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/></Borders><Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\" /><Font ss:FontName=\"Arial\" x:Family=\"Swiss\" ss:Color=\"#000000\" ss:Bold=\"1\"/><Interior ss:Color=\"#D8D8D8\" ss:Pattern=\"Solid\"/><Protection ss:Protected=\"0\"/></Style>");
        excelStr.Append("<Style ss:ID=\"s17\"><Borders><Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/></Borders><Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\" /> <Font ss:FontName=\"Arial\" x:Family=\"Swiss\" ss:Color=\"#000000\" ss:Bold=\"1\"/></Style>");
        excelStr.Append("<Style ss:ID=\"s18\"><Borders><Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/></Borders><Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\" /> <Font ss:FontName=\"Arial\" x:Family=\"Swiss\" ss:Color=\"#000000\" ss:Bold=\"1\"/><Interior ss:Color=\"#D8D8D8\" ss:Pattern=\"Solid\"/></Style>");
        excelStr.Append("<Style ss:ID=\"s19\"><Borders><Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/></Borders><Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\" /></Style>");
        excelStr.Append("<Style ss:ID=\"s20\"><Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\" /></Style>");
        excelStr.Append("<Style ss:ID=\"s24\"><Borders><Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/></Borders><Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Top\" ss:ReadingOrder=\"LeftToRight\" ss:WrapText=\"1\"/> </Style>");
        excelStr.Append("</Styles>");
        ArrayList at = new ArrayList();
        foreach (System.Data.DataTable tbl in Data_Set.Tables)
        {
            at.Add(tbl.TableName);
        }
        int Cnt = Data_Set.Tables.Count;
        for (int k = 0; k <= (Cnt - 1); k++)
        {
            sums = new Dictionary<String, double>();
            cnt_row = 0;
            c = 0;

            excelStr.Append(("<Worksheet ss:Name=\"" + SheetName[k] + "\">"));
            excelStr.Append("<Table>");
            excelStr.Append("<Row>");
            sht_cnt = 0;
            colcount = Data_Set.Tables[k].Columns.Count;

            excelStr.Append("</Row>");
            for (int i = 0; i <= 8; i++)
            {
                excelStr.Append("<Row>");
                excelStr.Append("<Cell></Cell>");
                excelStr.Append("<Cell></Cell>");
                excelStr.Append(("<Cell ss:StyleID=\"s16\"><Data ss:Type=\"String\">" + array[c] + "</Data></Cell>"));
                excelStr.Append(("<Cell ss:StyleID=\"s19\"><Data ss:Type=\"String\">" + val[c] + "</Data></Cell>"));
                if (c == 3 || c == 4)
                {
                    excelStr.Append(("<Cell ss:StyleID=\"s16\"><Data ss:Type=\"String\">(Transaction Date)</Data></Cell>"));
                    for (int j = 0; (j <= (colcount - 5)); j++)
                        excelStr.Append("<Cell></Cell>");
                }
                else
                {
                    for (int j = 0; (j <= (colcount - 4)); j++)
                        excelStr.Append("<Cell></Cell>");
                }
                excelStr.Append("</Row>");
                c++;
            }
            excelStr.Append("<Row>");
            for (int i = 0; i <= colcount; i++)
            {
                excelStr.Append("<Cell></Cell>");
            }
            excelStr.Append("</Row>");
            excelStr.Append("<Row>");
            excelStr.Append("<Cell ss:MergeAcross=\"" + (colcount - 1) + "\" ss:StyleID=\"s17\"><Data ss:Type=\"String\">Note: Amount is applicable only for Approved Transactions</Data></Cell>");

            excelStr.Append("</Row>");
            excelStr.Append("<Row>");
            excelStr.Append("<Cell ss:StyleID=\"s18\"></Cell>");
            excelStr.Append("<Cell ss:StyleID=\"s18\"><Data ss:Type=\"String\">" + "Year:" + DateTime.Now.Year + "</Data></Cell>");
            excelStr.Append("<Cell ss:MergeAcross=\"" + (colcount - 3) + "\" ss:StyleID=\"s18\"><Data ss:Type=\"String\">RuPay Transactions Details</Data></Cell>");

            excelStr.Append("</Row>");
            excelStr.Append("<Row>");
            for (int Col_cnt = 0; (Col_cnt <= (Data_Set.Tables[k].Columns.Count - 1)); Col_cnt++)
            {
                string a = Data_Set.Tables[k].Columns[Col_cnt].ColumnName;
                excelStr.Append(("<Cell ss:StyleID=\"s16\"><Data ss:Type=\"String\">" + a + "</Data></Cell>"));
                if (columns.Contains(a))
                {
                    sums.Add(a, 0);
                }
            }
            excelStr.Append("</Row>");
            excelStr.Append("<Row>");
            excelStr.Append("<Cell ss:MergeAcross=\"" + (colcount - 1) + "\" ss:StyleID=\"s18\"></Cell>");
            excelStr.Append("</Row>");
            foreach (DataRow dt in Data_Set.Tables[k].Rows)
            {
                cnt_row = (cnt_row + 1);
                if ((cnt_row > 65000))
                {
                    excelStr.Append("</Table>");
                    excelStr.Append(("</Worksheet>" + "\r\n"));
                    sht_cnt = (sht_cnt + 1);
                    excelStr.Append(("<Worksheet ss:Name=\"" + (SheetName[k] + ("_" + (sht_cnt.ToString() + "\">")))));
                    excelStr.Append("<Table>");
                    excelStr.Append("<Row>");
                    for (int Col_cnt = 0; (Col_cnt <= (Data_Set.Tables[k].Columns.Count - 1)); Col_cnt++)
                    {
                        string a = Data_Set.Tables[0].Columns[Col_cnt].ColumnName;
                        excelStr.Append(("<Cell ss:StyleID=\"s20\"><Data ss:Type=\"String\">" + (a + "</Data></Cell>")));
                    }
                    excelStr.Append("</Row>");
                    cnt_row = 1;
                    sht_cnt = 1;
                }
                excelStr.Append("<Row>");
                for (int i = 0; (i <= (Data_Set.Tables[k].Columns.Count - 1)); i++)
                {
                    //if(Information.IsNumeric(dt[i].ToString()))
                    //    excelStr.Append(("<Cell ss:StyleID=\"s20\"><Data ss:Type=\"Number\">" + (dt[i].ToString() + "</Data></Cell>")));
                    //else
                    excelStr.Append(("<Cell ss:StyleID=\"s20\"><Data ss:Type=\"String\">" + (dt[i].ToString() + "</Data></Cell>")));
                    if (columns.Contains(Data_Set.Tables[k].Columns[i].ColumnName))
                    {
                        string a = Data_Set.Tables[k].Columns[i].ColumnName;
                        // Response.Write(dt.Item(i).ToString)
                        sums[a] = (sums[a] + double.Parse((dt[i].ToString().Equals("") ? "0" : dt[i].ToString())));
                    }
                }
                excelStr.Append("</Row>");
            }
            excelStr.Append("<Row>");
            for (int i = 0; (i <= (colcount - (sums.Count + 3))); i++)
            {
                if ((i == 2))
                    excelStr.Append("<Cell  ss:StyleID=\"s16\"><Data ss:Type=\"String\" >TOTAL: </Data></Cell>");
                //else if ((i == 3))
                //    excelStr.Append(("<Cell  ss:StyleID=\"s16\"><Data ss:Type=\"Number\">" + (cnt_row.ToString() + "</Data></Cell>")));
                else
                    excelStr.Append("<Cell ss:StyleID=\"s16\"></Cell>");

            }
            foreach (KeyValuePair<String, double> kvp in sums)
                excelStr.Append(("<Cell ss:StyleID=\"s16\"><Data ss:Type=\"String\">" + (String.Format("{0:0.00}", kvp.Value) + "</Data></Cell>")));
            excelStr.Append("<Cell ss:StyleID=\"s16\"></Cell>");
            excelStr.Append("<Cell ss:StyleID=\"s16\"></Cell>");
            excelStr.Append("</Row>");

            excelStr.Append("<Row>");
            excelStr.Append("<Cell  ss:StyleID=\"s16\"><Data ss:Type=\"String\">End Of Report</Data></Cell>");
            excelStr.Append("<Cell ss:MergeAcross=\"" + (colcount - 2) + "\" ss:StyleID=\"s16\"></Cell>");
            excelStr.Append("</Row>");
            excelStr.Append("</Table>");
            excelStr.Append(("</Worksheet>" + "\r\n"));
        }
        excelStr.Append("</Workbook>");
        double cnt1 = excelStr.ToString().Length;
        string strFname = FnameWithPath;
        StreamWriter sw = new StreamWriter(strFname);
        sw.WriteLine(excelStr.ToString());
        excelStr.Clear();
        sw.Close();
        sw.Dispose();
        GC.Collect();
        // Process();
        ImageWrite1(FnameWithPath, IMG);
    }
    public void ExcelWrite(string FnameWithPath, string sheetname, DataSet Data_Set)
    {

        StringBuilder excelStr = new StringBuilder();
        excelStr.Append(("<?xml version=\"1.0\"?>" + "\r\n"));
        excelStr.Append(("<?mso-application progid=\"Excel.Sheet\"?>" + "\r\n"));
        excelStr.Append(("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"" + "\r\n"));
        excelStr.Append(("xmlns:o=\"urn:schemas-microsoft-com:office:office\"" + "\r\n"));
        excelStr.Append(("xmlns:x=\"urn:schemas-microsoft-com:office:excel\"" + "\r\n"));
        excelStr.Append(("xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"" + "\r\n"));
        excelStr.Append(("xmlns:html=\"http://www.w3.org/TR/REC-html40\">" + "\r\n"));
        excelStr.Append("<Styles>");
        excelStr.Append("<Style ss:ID=\"N0\"> <NumberFormat ss:Format=\"Fixed\"/> </Style>");
        excelStr.Append("<Style ss:ID=\"T0\"> <NumberFormat ss:Format=\"@\"/> </Style>");
        excelStr.Append("<Style ss:ID=\"N1\"> <NumberFormat ss:Format=\"Fixed\"/> </Style>");
        excelStr.Append("<Style ss:ID=\"T1\"> <NumberFormat ss:Format=\"@\"/> </Style>");

        excelStr.Append("<Style ss:ID=\"s16\"><Borders><Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/></Borders><Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/><Font ss:FontName=\"Arial\" x:Family=\"Swiss\" ss:Color=\"#000000\" ss:Bold=\"1\"/><Interior ss:Color=\"#D8D8D8\" ss:Pattern=\"Solid\"/><Protection ss:Protected=\"0\"/></Style>");
        excelStr.Append("<Style ss:ID=\"s17\"><Borders><Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/></Borders><Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/> <Font ss:FontName=\"Arial\" x:Family=\"Swiss\" ss:Color=\"#000000\" ss:Bold=\"1\"/></Style>");
        excelStr.Append("<Style ss:ID=\"s18\"><Borders><Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/></Borders><Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/> <Font ss:FontName=\"Arial\" x:Family=\"Swiss\" ss:Color=\"#000000\" ss:Bold=\"1\"/><Interior ss:Color=\"#D8D8D8\" ss:Pattern=\"Solid\"/></Style>");
        excelStr.Append("<Style ss:ID=\"s19\"><Borders><Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/></Borders><Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/></Style>");
        excelStr.Append("<Style ss:ID=\"s20\"><Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Bottom\"/></Style>");
        excelStr.Append("<Style ss:ID=\"s21\"><Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Top\" ss:ReadingOrder=\"LeftToRight\"/><Borders><Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#9EB6E4\"/><Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#7292CC\"/><Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#7292CC\"/><Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#7292CC\"/></Borders><Font ss:FontName=\"Tahoma\" x:CharSet=\"1\" ss:Size=\"9\" ss:Color=\"#FFFFFF\" ss:Bold=\"1\"/><Interior ss:Color=\"#4C68A2\" Pattern=\"Solid\"/><Protection ss:Protected=\"0\"/></Style>");
        excelStr.Append("<Style ss:ID=\"s22\"><Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Top\" ss:ReadingOrder=\"LeftToRight\"/><Borders><Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#9EB6E4\"/><Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#9EB6E4\"/><Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" ss:Color=\"#9EB6E4\"/></Borders><Font ss:FontName=\"Tahoma\" x:CharSet=\"1\" ss:Color=\"#FFFFFF\" ss:Bold=\"1\"/><Interior ss:Color=\"#7292CC\" ss:Pattern=\"Solid\"/><Protection ss:Protected=\"0\"/></Style>");
        excelStr.Append("<Style ss:ID=\"s24\"><Borders><Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/><Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\"/></Borders><Alignment ss:Horizontal=\"Center\" ss:Vertical=\"Top\" ss:ReadingOrder=\"LeftToRight\" ss:WrapText=\"1\"/> </Style>");
        excelStr.Append("</Styles>");
        excelStr.Append(("<Worksheet ss:Name=\"" + sheetname + "\">"));
        excelStr.Append("<Table>");
        excelStr.Append("<Row>");
        for (int i = 0; i < Data_Set.Tables[0].Columns.Count; i++)
        {
            excelStr.Append(("<Cell ss:StyleID=\"s22\"><Data ss:Type=\"String\">" + Data_Set.Tables[0].Columns[i].ColumnName + "</Data></Cell>"));
        }
        excelStr.Append("</Row>");
        for (int i = 0; i < Data_Set.Tables[0].Rows.Count; i++)
        {
            excelStr.Append("<Row>");
            if (i == Data_Set.Tables[0].Rows.Count - 1)
            {
                for (int j = 0; j < Data_Set.Tables[0].Columns.Count; j++)
                    excelStr.Append(("<Cell ss:StyleID=\"s22\"><Data ss:Type=\"String\">" + Data_Set.Tables[0].Rows[i][j].ToString() + "</Data></Cell>"));
            }
            else
            {
                for (int j = 0; j < Data_Set.Tables[0].Columns.Count; j++)
                    excelStr.Append(("<Cell ss:StyleID=\"s20\"><Data ss:Type=\"String\">" + Data_Set.Tables[0].Rows[i][j].ToString() + "</Data></Cell>"));
            }
            excelStr.Append("</Row>");
        }
        excelStr.Append("</Table>");
        excelStr.Append(("</Worksheet>" + "\r\n"));

        excelStr.Append("</Workbook>");
        double cnt1 = excelStr.ToString().Length;
        string strFname = FnameWithPath;
        if (!Directory.Exists(FnameWithPath.Substring(FnameWithPath.LastIndexOf("\\") + 1)))
            Directory.CreateDirectory(FnameWithPath.Substring(0, FnameWithPath.LastIndexOf("\\")));
        StreamWriter sw = new StreamWriter(strFname);
        sw.WriteLine(excelStr.ToString());
        excelStr.Clear();
        sw.Close();
        sw.Dispose();
        GC.Collect();
        // Process();

    }
    public void TextWrite(string FnameWithPath, string Filename, DataSet Data_Set)
    {
        StringBuilder str = new StringBuilder();
        for (int i = 0; i < Data_Set.Tables[0].Columns.Count; i++)
            str.Append(Data_Set.Tables[0].Columns[i].ColumnName + ",");
        str.Append("\r\n");
        for (int i = 0; i < Data_Set.Tables[0].Rows.Count; i++)
        {
            for (int j = 0; j < Data_Set.Tables[0].Columns.Count; j++)
                str.Append(Data_Set.Tables[0].Rows[i][j].ToString() + ",");
            str.Append("\r\n");
        }
        double cnt1 = str.ToString().Length;
        string strFname = FnameWithPath;
        if (!Directory.Exists(FnameWithPath.Substring(FnameWithPath.LastIndexOf("\\") + 1)))
            Directory.CreateDirectory(FnameWithPath.Substring(0, FnameWithPath.LastIndexOf("\\")));
        StreamWriter sw = File.CreateText(strFname);
        sw.WriteLine(str.ToString());
        str.Clear();
        sw.Close();
    }
    public void create_zip(string path, string zippath, string filename)
    {
        string dtdir = path.Substring(0, path.LastIndexOf("\\") + 1) + DateTime.Now.ToString("ddMMMyy");
        string reportdir = dtdir + "\\" + path.Substring(path.LastIndexOf("\\") + 1, (path.Length - path.LastIndexOf("\\")) - 1);
        if (!Directory.Exists(dtdir))
        {
            Directory.CreateDirectory(dtdir);
            if (!Directory.Exists(reportdir))
                Directory.CreateDirectory(reportdir);
        }
        else
        {
            if (!Directory.Exists(reportdir))
                Directory.CreateDirectory(reportdir);
        }
        string[] fileist = Directory.GetFiles(path);
        string fileNew;
        if (fileist.Length == 0)
        {
            return;
        }

        //fileNew = path.Substring(0, path.LastIndexOf("\\") + 1) + filename + "\\" + path.Substring(path.LastIndexOf("\\") + 1, (path.Length - path.LastIndexOf("\\")) - 1) +".zip";

        fileNew = filename + ".zip";

        ICSharpCode.SharpZipLib.Zip.ZipOutputStream zipoutputstream = new ICSharpCode.SharpZipLib.Zip.ZipOutputStream(File.Create(reportdir + "\\" + fileNew));
        zipoutputstream.SetLevel(6);
        //ICSharpCode.SharpZipLib.Checksums.Crc32 objcrc32 = new ICSharpCode.SharpZipLib.Checksums.Crc32();
        for (int i = 0; i < fileist.Length; i++)
        {
            FileStream stream = File.OpenRead(fileist[i].ToString());
            // Dim buff(stream.Length - 1) As Byte
            byte[] buff = new byte[stream.Length];
            ICSharpCode.SharpZipLib.Zip.ZipEntry zipentry = new ICSharpCode.SharpZipLib.Zip.ZipEntry(fileist[i].ToString().Substring((fileist[i].ToString().LastIndexOf("\\") + 1)));
            stream.Read(buff, 0, buff.Length);
            zipentry.DateTime = DateTime.Now;
            zipentry.Size = stream.Length;
            // stream.Close()
            // objcrc32.Reset()
            // objcrc32.Update(buff)
            // zipentry.Crc = objcrc32.Value
            zipoutputstream.PutNextEntry(zipentry);
            zipoutputstream.Write(buff, 0, buff.Length);
            StreamUtils.Copy(stream, zipoutputstream, buff);
            stream.Close();
        }
        zipoutputstream.Flush();
        zipoutputstream.Finish();
        zipoutputstream.Close();
        DirectoryInfo dir = new DirectoryInfo(path);
        foreach (FileInfo file in dir.GetFiles())
            file.Delete();
        foreach (DirectoryInfo d in dir.GetDirectories())
            d.Delete(true);
        //Directory.Delete(path);


    }
}