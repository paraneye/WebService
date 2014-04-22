using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Transactions;
using System.IO;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.Common;
using Element.Sigma.Web.Biz.Types.ProjectSettings;
using Element.Sigma.Web.Biz.Auth;
using Element.Sigma.Web.Biz.Types.Auth;


namespace Element.Sigma.Web.Biz.ProjectSettings
{
    public class PersonnelMgr
    {
        public SigmaResultType GetPersonnel(string personnelId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PersonnelId", personnelId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetPersonnel", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListPersonnel(string offset, string max, List<string> s_option, List<string> s_key, string o_option, string o_desc)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            for (int i = 0; i < s_option.Count; i++)
            {
                parameters.Add(new SqlParameter(s_option[i], s_key[i]));
            }

            parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
            parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));

            parameters.Add(new SqlParameter("@SortColumn", o_option));
            parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            parameters.Add(new SqlParameter("@ProjectId", userinfo.CurrentProjectId));


            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListPersonnel", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddPersonnel(TypePersonnel objPersonnel)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            objPersonnel.CreatedBy = userinfo.SigmaUserId;

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Name", objPersonnel.Name));
            paramList.Add(new SqlParameter("@FirstName", objPersonnel.FirstName));
            paramList.Add(new SqlParameter("@LastName", objPersonnel.LastName));
            paramList.Add(new SqlParameter("@CompanyId", objPersonnel.CompanyId));
            paramList.Add(new SqlParameter("@PersonnelTypeCode", objPersonnel.PersonnelTypeCode));
            paramList.Add(new SqlParameter("@PhotoUrl", objPersonnel.PhotoUrl));
            paramList.Add(new SqlParameter("@EmployeeId", objPersonnel.EmployeeId));
            paramList.Add(new SqlParameter("@PhoneNumber", objPersonnel.PhoneNumber));
            paramList.Add(new SqlParameter("@EmailAddress", objPersonnel.EmailAddress));
            paramList.Add(new SqlParameter("@NfcCardId", objPersonnel.NfcCardId));
            paramList.Add(new SqlParameter("@PinCode", objPersonnel.PinCode));
            paramList.Add(new SqlParameter("@CreatedBy", objPersonnel.CreatedBy));
            paramList.Add(new SqlParameter("@ProjectId", userinfo.CurrentProjectId));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddPersonnel", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType AddPersonnelByTemplate(TypePersonnel objPersonnel)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            objPersonnel.CreatedBy = userinfo.SigmaUserId;

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Name", objPersonnel.Name));
            paramList.Add(new SqlParameter("@FirstName", objPersonnel.FirstName));
            paramList.Add(new SqlParameter("@LastName", objPersonnel.LastName));
            paramList.Add(new SqlParameter("@CompanyName", objPersonnel.CompanyName));
            paramList.Add(new SqlParameter("@RoleName", objPersonnel.RoleName));
            paramList.Add(new SqlParameter("@PhotoUrl", objPersonnel.PhotoUrl));
            paramList.Add(new SqlParameter("@EmployeeId", objPersonnel.EmployeeId));
            paramList.Add(new SqlParameter("@PhoneNumber", objPersonnel.PhoneNumber));
            paramList.Add(new SqlParameter("@EmailAddress", objPersonnel.EmailAddress));
            paramList.Add(new SqlParameter("@NfcCardId", objPersonnel.NfcCardId));
            paramList.Add(new SqlParameter("@PinCode", objPersonnel.PinCode));
            paramList.Add(new SqlParameter("@CreatedBy", objPersonnel.CreatedBy));
            paramList.Add(new SqlParameter("@ProjectId", userinfo.CurrentProjectId));
            SqlParameter outParam = new SqlParameter("@ExMessage", SqlDbType.NVarChar, 100);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddPersonnelByTemplate", paramList.ToArray());
                result.IsSuccessful = true;
                if (!string.IsNullOrEmpty(outParam.Value.ToString()))
                    result.ErrorMessage = outParam.Value.ToString();

                scope.Complete();

            }

            return result;
        }


        public SigmaResultType UpdatePersonnel(TypePersonnel objPersonnel)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            objPersonnel.UpdatedBy = userinfo.SigmaUserId;

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PersonnelId", objPersonnel.PersonnelId),
					new SqlParameter("@Name", objPersonnel.Name),
					new SqlParameter("@FirstName", objPersonnel.FirstName),
					new SqlParameter("@LastName", objPersonnel.LastName),
					new SqlParameter("@CompanyId", objPersonnel.CompanyId),
					new SqlParameter("@PersonnelTypeCode", objPersonnel.PersonnelTypeCode),
					new SqlParameter("@PhotoUrl", objPersonnel.PhotoUrl),
					new SqlParameter("@EmployeeId", objPersonnel.EmployeeId),
					new SqlParameter("@PhoneNumber", objPersonnel.PhoneNumber),
					new SqlParameter("@EmailAddress", objPersonnel.EmailAddress),
					new SqlParameter("@NfcCardId", objPersonnel.NfcCardId),
					new SqlParameter("@PinCode", objPersonnel.PinCode),
					new SqlParameter("@UpdatedBy", objPersonnel.UpdatedBy),
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdatePersonnel", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }
        public SigmaResultType RemovePersonnel(TypePersonnel objPersonnel)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@PersonnelId", objPersonnel.PersonnelId)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemovePersonnel", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }


        public SigmaResultType MultiPersonnel(List<TypePersonnel> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypePersonnel anObj in listObj)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            AddPersonnel(anObj);
                            break;
                        case "U":
                            UpdatePersonnel(anObj);
                            break;
                        case "D":
                            RemovePersonnel(anObj);
                            break;
                    }
                }
                scope.Complete();
                result.IsSuccessful = true;
            }

            return result;
        }

        public SigmaResultType ImportPersonnelFromExcel(string filePath, string exportfilepath)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            DataTable dt = new DataTable();
            DataTable tmpDt = new DataTable();
            SigmaResultType result = new SigmaResultType();

            dt = Element.Shared.Common.ImportHelper.ImportWorkSheet(filePath, false);

            DataTable tmpdt = new DataTable();
            tmpdt = dt.Copy();
            tmpdt.Rows.Clear();
            tmpdt.Columns.Add("Fail reason");

            int failCnt = 0;

            foreach (DataRow r in dt.Rows)
            {
                TypePersonnel obj = new TypePersonnel();
                obj.EmployeeId = r[0].ToString();
                obj.FirstName = r[1].ToString();
                obj.LastName = r[2].ToString();
                obj.PhoneNumber = r[3].ToString();
                obj.EmailAddress = r[4].ToString();
                obj.RoleName = r[5].ToString();
                obj.NfcCardId = r[6].ToString();
                obj.PinCode = r[7].ToString();
                obj.CompanyName = r[8].ToString();
                obj.CreatedBy = userinfo.SigmaUserId;
                obj.ProjectId = userinfo.CurrentProjectId;

                if (string.IsNullOrEmpty(GetFailreasonForRequiredPersonnel(r)))
                {
                    SigmaResultType rst = AddPersonnelByTemplate(obj);

                    if (rst.ErrorMessage != null)
                    {
                        tmpdt.Rows.Add(r.ItemArray);
                        tmpdt.Rows[tmpdt.Rows.Count - 1]["Fail reason"] = rst.ErrorMessage.ToString();
                        failCnt++;
                    }
                }
                else
                {
                    tmpdt.Rows.Add(r.ItemArray);
                    tmpdt.Rows[tmpdt.Rows.Count - 1]["Fail reason"] = GetFailreasonForRequiredPersonnel(r);
                    failCnt++;
                }
            }
            TypeImportHistory ImportHistory = new TypeImportHistory();
            ImportHistory.ImportCategory = "HR";
            ImportHistory.ImportedFileName = Path.GetFileName(filePath).ToString();
            ImportHistory.ImportedDate = DateTime.Now.ToString();
            ImportHistory.TotalCount = dt.Rows.Count;
            ImportHistory.SuccessCount = dt.Rows.Count - failCnt;
            ImportHistory.FailCount = failCnt;
            ImportHistory.CreatedBy = userinfo.SigmaUserId;
            ImportHistoryMgr HistoryMgr = new ImportHistoryMgr();
            result = HistoryMgr.AddImportHistory(ImportHistory);

            //if exists error list
            if (tmpdt.Rows.Count > 0)
            {
                if (!System.IO.Directory.Exists(exportfilepath))
                {
                    System.IO.Directory.CreateDirectory(exportfilepath);
                }

                //excel file generate for direct call 'export' link
                Export2Excel.ConvertExcelfromData(tmpdt, result.ScalarValue + Path.GetExtension(filePath), exportfilepath);

                //csv file generate for import error list view
                Export2Excel.ConvertCSVFile(tmpdt, result.ScalarValue + ".csv", exportfilepath);

            }
            return result;
        }

        private string GetFailreasonForRequiredPersonnel(DataRow r)
        {
            string rslt = string.Empty;
            if (string.IsNullOrEmpty(r[0].ToString()))
                rslt += "EmployeeID,";
            if (string.IsNullOrEmpty(r[1].ToString()))
                rslt += "FirstName,";
            if (string.IsNullOrEmpty(r[2].ToString()))
                rslt += "LastName,";
            if (string.IsNullOrEmpty(r[3].ToString()))
                rslt += "PhoneNumber,";
            if (string.IsNullOrEmpty(r[5].ToString()))
                rslt += "Role,";
            if (string.IsNullOrEmpty(r[6].ToString()) && r[5].ToString().ToUpper() == "CREW")
                rslt += "NfcCardId,";
            if (string.IsNullOrEmpty(r[7].ToString()) && r[5].ToString().ToUpper() == "CREW")
                rslt += "PinCode,";
            if (string.IsNullOrEmpty(r[8].ToString()))
                rslt += "Company,";

            rslt = rslt.Length > 0 ? rslt.Substring(0, rslt.Length - 1) + " is required." : string.Empty;
            return rslt;
        }

    }
}
