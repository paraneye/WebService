using Element.Reveal.DataLibrary;
using Element.Shared.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Element.Sigma.Web.Biz.TrueTask
{
    public class TimeProgress
    {
        public List<TimeProgressLogDTO> GetTimeProgressLog(string personnelId, int maxLogCout, int projectId, string disciplineCode)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@personnelId", personnelId),
                    new SqlParameter("@maxLogCout", maxLogCout),
                    new SqlParameter("@projectId", projectId),
                    new SqlParameter("@disciplineCode", disciplineCode)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetTimeProgressLog", parameters);
            List<TimeProgressLogDTO> result = DTOHelper.DataTableToListDTO<TimeProgressLogDTO>(ds);
            return result;
        }

        public List<ComboBoxDTO> GetAvailableCollectionForForemanUncompleted_Combo(string foremanId, int projectId, string disciplineCode)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@personnelId", foremanId),
                    new SqlParameter("@projectId", projectId),
                    new SqlParameter("@disciplineCode", disciplineCode)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetAvailableCollectionByForemanUncompleted", parameters);  //sp_get_available_collection_by_foreman_uncompleted
            List<ComboBoxDTO> result = DTOHelper.DataTableToListDTO<ComboBoxDTO>(ds);
            return result;
        }

        public List<DrawingDTO> GetDrawingByIwp(int iwpId, int projectId, string disciplineCode)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@iwpId", iwpId),
                    new SqlParameter("@projectId", projectId),
                    new SqlParameter("@disciplineCode", disciplineCode)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetDrawingByIwp", parameters);
            List<DrawingDTO> result = DTOHelper.DataTableToListDTO<DrawingDTO>(ds);
            return result;
        }

        public List<TimeProgressInputDTO> JsonGetComponentProgressByIwpDrawing(int iwpId, int drawingId, int projectId, string disciplineCode)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@iwpId", iwpId),
                    new SqlParameter("@drawingId", drawingId),
                    new SqlParameter("@projectId", projectId),
                    new SqlParameter("@disciplineCode", disciplineCode)
                };

            DataSet ds = SqlHelper.ExecuteDataset(connStr, "tsp_GetComponentprogressByIwpDrawing", parameters);
            List<TimeProgressInputDTO> result = DTOHelper.DataTableToListDTO<TimeProgressInputDTO>(ds);
            return result;
        }

    }
}
