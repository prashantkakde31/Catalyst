using ClosedXML.Excel;
using Interpidians.Catalyst.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Interpidians.Catalyst.Client.Web.Helpers
{
    public sealed class ExcelHelper
    {
        #region Properties

        /// <summary>
        /// Comma separeted list of columns that needs to be excluded.
        /// </summary>
        public string ColumnListToExclude = string.Empty;

        #endregion

        #region Helper Methods

        /// <summary>
        /// Exports to excel.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="iList">The list.</param>
        /// <param name="downloadFileName">Name of download file.</param>
        public void ExportToExcel<T>(IEnumerable<T> iList, string downloadFileName, string workSheetName)
        {
            DataTable dtTable = null;
            string[] excludeColumnLists = this.ColumnListToExclude.Split(',');
            using (dtTable = new DataTable())
            {
                if (string.IsNullOrEmpty(workSheetName))
                {
                    workSheetName = "Table1";
                }
                dtTable.TableName = workSheetName;

                Type listType;
                if (iList.Any())
                {
                    listType = iList.ElementAt(0).GetType();
                }
                else
                {
                    listType = typeof(T);
                }

                if (listType != null)
                {
                    PropertyInfo[] properties = listType.GetProperties();
                    foreach (PropertyInfo property in properties)
                    {
                        if (property.GetCustomAttributes(typeof(IncludeInExcelAttribute), false).Length > 0)
                        {
                            bool isColumnExist = false;
                            if (excludeColumnLists.Length > 0)
                            {
                                for (int i = 0; i < excludeColumnLists.Length; i++)
                                {
                                    if (property.Name.ToUpper() == excludeColumnLists[i].ToUpper())
                                    {
                                        isColumnExist = true;
                                    }
                                }
                            }

                            if (!isColumnExist)
                            {
                                DataColumn dtColumn = null;
                                using (dtColumn = new DataColumn())
                                {
                                    dtColumn.ColumnName = property.Name;
                                    dtTable.Columns.Add(dtColumn);
                                }
                            }
                        }
                    }

                    foreach (object item in iList)
                    {
                        DataRow dr = dtTable.NewRow();
                        foreach (DataColumn col in dtTable.Columns)
                        {
                            dr[col] = listType.GetProperty(col.ColumnName).GetValue(item, null);
                        }
                        dtTable.Rows.Add(dr);
                    }

                    ConvertToExcel(dtTable, downloadFileName);
                }
            }
        }

        /// <summary>
        /// Converts to excel.
        /// </summary>
        /// <param name="dtList">The dt list.</param>
        /// <param name="downloadFileName">Name of the download file.</param>
        private void ConvertToExcel(DataTable dtList, string downloadFileName)
        {
            try
            {
                XLWorkbook wb = new XLWorkbook();
                wb.Worksheets.Add(dtList);

                HttpResponse httpResponse = HttpContext.Current.Response;
                httpResponse.Clear();
                httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                httpResponse.AddHeader("Content-Disposition", "attachment; filename=" + downloadFileName + ".xlsx");

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    wb.SaveAs(memoryStream);
                    memoryStream.WriteTo(httpResponse.OutputStream);
                }

                httpResponse.End();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Imports the excel.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public DataTable ImportExcel(string fileName)
        {
            DataTable dtExcel = dtExcel = new DataTable();
            XLWorkbook workbook = new XLWorkbook(fileName);
            IXLWorksheet worksheet = workbook.Worksheets.First();
            IXLRange range = worksheet.RangeUsed();
            if (range != null)
            {
                int colCount = range.ColumnCount();

                foreach (IXLRangeRow row in range.RowsUsed())
                {
                    //for header row only
                    if (row.RowNumber() > 1)
                    {
                        object[] rowData = new object[colCount];
                        Int32 i = 0;
                        row.Cells().ForEach(c => rowData[i++] = c.Value);
                        dtExcel.Rows.Add(rowData);
                    }
                    else
                    {
                        row.Cells().ForEach(c => dtExcel.Columns.Add(c.Value.ToString()));
                    }
                }
            }
            return dtExcel;
        }



        #endregion
    }
}