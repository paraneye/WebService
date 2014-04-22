using System;
using System.Data;
using System.Text;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Runtime.InteropServices;
using DocumentFormat.OpenXml;
using ExportToExcel;

namespace Element.Shared.Common
{

    public class Export2Excel
    {

        private static string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        /// <summary>
        /// Export DataTable TO Excel File
        /// </summary>
        /// <param name="dt">DataTable Data</param>
        /// <param name="filename">File Name</param>
        /// <returns></returns>
        public static bool ConvertExcelfromData(DataTable dt, string filename)
        {
            bool bResult = false;
            string path = @"C:\SigmaStorage\Template\company\project\exportfiles\";
            //string path = filepath();

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            string excelFilename = path + filename+".xlsx";
            bResult = CreateExcelFile.CreateExcelDocument(dt, excelFilename);
            return bResult;
        }

        /// <summary>
        /// Export DataTable to CSV 
        /// </summary>
        /// <param name="dtDataTablesList"></param>
        /// <param name="filename"></param>
        public static void ConvertCSVFile(DataTable dtDataTablesList, string filename)
        {
            string path = @"C:\SigmaStorage\Template\company\project\exportfiles\";
            //string path = filepath();

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            string CSVFilename = path + filename+".csv";

            StreamWriter sw = new StreamWriter(CSVFilename, false);

            int iColCount = dtDataTablesList.Columns.Count;// 

            for (int i = 0; i < iColCount; i++)
            {
                sw.Write(dtDataTablesList.Columns[i]); //Head 

                if (i < iColCount - 1)
                {
                    sw.Write("|||");
                }
            }
            sw.Write(sw.NewLine);

            // Now write all the rows.
            foreach (DataRow dr in dtDataTablesList.Rows)
            {
                for (int i = 0; i < iColCount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        sw.Write(dr[i].ToString());//Value
                    }

                    if (i < iColCount - 1)
                    {
                        sw.Write("|||");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        public static bool ConvertExcelfromData(DataTable dt, string filename, string filepath)
        {
            bool bResult = false;

            if (!System.IO.Directory.Exists(filepath))
            {
                System.IO.Directory.CreateDirectory(filepath);
            }

            bResult = CreateExcelFile.CreateExcelDocument(dt, filepath + "\\" + filename);
            return bResult;
        }

        public static bool ConvertCSVFile(DataTable dt, string filename, string filepath)
        {
            bool bResult = false;

            if (!System.IO.Directory.Exists(filepath))
            {
                System.IO.Directory.CreateDirectory(filepath);
            }

            try
            {
                // Create the CSV file to which grid data will be exported.
                StreamWriter sw = new StreamWriter(filepath + "\\" + filename, false);
                // First we will write the headers.
                //DataTable dt = m_dsProducts.Tables[0];
                int iColCount = dt.Columns.Count;

                for (int i = 0; i < iColCount; i++)
                {
                    sw.Write(dt.Columns[i]);

                   
                    if (i < iColCount - 1)
                    {
                        sw.Write("|||");
                    }
                }
                sw.Write(sw.NewLine);

                // Now write all the rows.

                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < iColCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            sw.Write(dr[i].ToString());
                        }
                        if (i < iColCount - 1)
                        {
                            sw.Write("|||");
                        }
                    }

                    sw.Write(sw.NewLine);
                }
                sw.Close();

                bResult = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return bResult;

        }

        //private static string filepath()
        //{
        //    //string path = @"C:\SigmaStorage\Template\company\project\exportfiles\";

        //    TypeUserInfo userinfo = AuthMgr.GetUserInfo();
        //    string savepath = string.Empty;
        //    string rootPath = string.Empty;

        //    string iisvirtualpath = HttpContext.Current.Server.MapPath("/SigmaStorage");
        //    rootPath = System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentTemplate"];
            
        //    savepath = iisvirtualpath + rootPath;

        //    savepath = savepath + userinfo.CompanyName + "\\" + userinfo.CurrentProjectId + "\\" + "Exportfiles\\";
            
        //    return savepath;
        //}

    }

}