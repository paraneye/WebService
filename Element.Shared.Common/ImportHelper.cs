using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Data.Common;


namespace Element.Shared.Common
{
    public static class  ImportHelper
    {
        public static DataTable ImportWorkSheet(string excelFile, bool hasHeaderRow)
        {
            return ImportWorkSheet(excelFile, hasHeaderRow, false, null);
        }

        public static DataTable ImportWorkSheet(string excelFile, bool hasHeaderRow, bool allText, string tabName)
        {
            string connectionString = GetExcelConnectionString(excelFile, hasHeaderRow, allText);
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                if (Path.GetExtension(excelFile).Equals(".csv", StringComparison.OrdinalIgnoreCase))
                    tabName = Path.GetFileName(excelFile);
                else
                    tabName = EnsureTableName(connection, tabName);

                string selectString = string.Format("SELECT * FROM [{0}]", tabName);
                DataTable table = new DataTable(tabName);

                using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectString, connection))
                    adapter.Fill(table);

                return table;
            }
            
        }

        public static string GetExcelConnectionString(string filePath, bool hasHeaderRow, bool allText)
        {
            string connectionString;
            string ext = Path.GetExtension(filePath);
            if (ext.Equals(".csv", StringComparison.OrdinalIgnoreCase))
            {
                connectionString = string.Format(

                    @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}; Extended Properties=""text;FMT=Delimited;{1}{2}""",
                    filePath.Remove(filePath.IndexOf(Path.GetFileName(filePath))),
                    hasHeaderRow ? "HDR=YES;" : "HDR=NO;",
                    allText ? "IMEX=1" : string.Empty);

            }
            else if (ext.Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                connectionString = string.Format(
                    @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Extended Properties=""Excel 12.0 Xml;{1}{2}{3}""",
                    filePath,
                    hasHeaderRow ? "HDR=YES;" : "HDR=NO;",
                    allText ? "IMEX=1;" : "IMEX=1;",
                    "TypeGuessRows=0;ImportMixedTypes=Text");
            }
            else //assume normal excel
            {
                connectionString = string.Format(
                    @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}; Extended Properties=""Excel 8.0;{1}{2}{3}""",
                    filePath,
                    hasHeaderRow ? "HDR=YES;" : "HDR=NO;",
                    allText ? "IMEX=1;" : "IMEX=1;",
                    "TypeGuessRows=0;ImportMixedTypes=Text");
            }

            return connectionString;
        }

        private static string EnsureTableName(DbConnection connection, string tabName)
        {
            if (string.IsNullOrEmpty(tabName))
            {
                DataTable worksheets = connection.GetSchema("Tables");
                foreach (DataRow row in worksheets.Rows)
                {
                    tabName = (string)row["TABLE_NAME"];

                    if (tabName.EndsWith("$") || tabName.EndsWith("$'"))
                        return tabName;
                }
            }
            else if (!tabName.EndsWith("$"))
                tabName += "$";

            return tabName;

        }

      
    }

}
