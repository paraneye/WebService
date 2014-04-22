﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.IO;
using Element.Shared.Common;
using Element.Sigma.Web.Biz.Common;
using Element.Sigma.Web.Biz.Auth;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.Types.ProjectSettings;
using Element.Sigma.Web.Biz.Types.Auth;

namespace Element.Sigma.Web.Biz.GlobalSettings
{
    public class CostCodeMgr
    {
        #region CostCode

        public SigmaResultType GetCostCode(string costCodeId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@CostCodeId", costCodeId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetCostCode", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListCostCode(string offset, string max, List<string> s_option, List<string> s_key, string o_option, string o_desc)
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


            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListCostCode", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddCostCode(TypeCostCode objCostCode)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            objCostCode.CompanyId = userinfo.CompanyId.ToString();
            objCostCode.CreatedBy = userinfo.SigmaUserId;

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CostCode", objCostCode.CostCode));
            paramList.Add(new SqlParameter("@Description", objCostCode.Description));
            paramList.Add(new SqlParameter("@CompanyId", objCostCode.CompanyId));
            paramList.Add(new SqlParameter("@CodeRegisterCompanyId", objCostCode.CodeRegisterCompanyId));
            paramList.Add(new SqlParameter("@CostCodeType", objCostCode.CostCodeType));
            paramList.Add(new SqlParameter("@UomCode", objCostCode.UomCode));
            paramList.Add(new SqlParameter("@CreatedBy", objCostCode.CreatedBy));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddCostCode", paramList.ToArray());
                if (result.AffectedRow > 0)
                {
                    result.IsSuccessful = true;
                    result.ScalarValue = (int)outParam.Value;
                }
                else
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "CostCode is duplicated";
                }
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType UpdateCostCode(TypeCostCode objCostCode)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            objCostCode.CompanyId = userinfo.CompanyId.ToString();
            objCostCode.UpdatedBy = userinfo.SigmaUserId;

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@CostCodeId", objCostCode.CostCodeId),
					new SqlParameter("@CostCode", objCostCode.CostCode),
					new SqlParameter("@Description", objCostCode.Description),
					new SqlParameter("@CompanyId", objCostCode.CompanyId),
					new SqlParameter("@CodeRegisterCompanyId", objCostCode.CodeRegisterCompanyId),
					new SqlParameter("@CostCodeType", objCostCode.CostCodeType),
					new SqlParameter("@UomCode", objCostCode.UomCode),
					new SqlParameter("@UpdatedBy", objCostCode.UpdatedBy),
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateCostCode", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType RemoveCostCode(TypeCostCode objCostCode)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@CostCodeId", objCostCode.CostCodeId)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveCostCode", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType MultiCostCode(List<TypeCostCode> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypeCostCode anObj in listObj)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            AddCostCode(anObj);
                            break;
                        case "U":
                            UpdateCostCode(anObj);
                            break;
                        case "D":
                            RemoveCostCode(anObj);
                            break;
                    }
                }

                scope.Complete();
                result.IsSuccessful = true;
            }

            return result;
        }

        public DataSet ListCostCodeForMaterial()
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListCostCodeForMaterial", parameters);

            // return
            return ds;
        }

        public SigmaResultType ImportCostCodeFromExcel(string filePath, string exportfilepath)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            DataTable dt = new DataTable();
            DataTable tmpDt = new DataTable();
            SigmaResultType result = new SigmaResultType();

            dt = Element.Shared.Common.ImportHelper.ImportWorkSheet(filePath, true);

            DataTable tmpdt = new DataTable();
            tmpdt = dt.Copy();
            tmpdt.Rows.Clear();
            tmpdt.Columns.Add("Fail reason");

            int failCnt = 0;

            foreach (DataRow r in dt.Rows)
            {
                TypeCostCode obj = new TypeCostCode();
                obj.CostCode = r[0].ToString();
                obj.Description = r[1].ToString();
                obj.CostCodeType = r[2].ToString();
                obj.CompanyId = userinfo.CompanyId.ToString();
                obj.UpdatedBy = userinfo.SigmaUserId;


                if (string.IsNullOrEmpty(GetFailreasonForRequired(r)))
                {
                    SigmaResultType rst = AddCostCode(obj);

                    if (!rst.IsSuccessful)
                    {
                        tmpdt.Rows.Add(r.ItemArray);
                        tmpdt.Rows[tmpdt.Rows.Count - 1]["Fail reason"] = rst.ErrorMessage.ToString();
                        failCnt++;
                    }
                }
                else
                {
                    tmpdt.Rows.Add(r.ItemArray);
                    tmpdt.Rows[tmpdt.Rows.Count - 1]["Fail reason"] = GetFailreasonForRequired(r);
                    failCnt++;
                }
            }
            TypeImportHistory ImportHistory = new TypeImportHistory();
            ImportHistory.ImportCategory = "CostCode";
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

        private string GetFailreasonForRequired(DataRow r)
        {
            string rslt = string.Empty;
            if (string.IsNullOrEmpty(r[0].ToString()))
                rslt += "CostCode,";
            if (string.IsNullOrEmpty(r[1].ToString()))
                rslt += "Description,";
            if (string.IsNullOrEmpty(r[2].ToString()))
                rslt += "Direct,";

            rslt = rslt.Length > 0 ? rslt.Substring(0, rslt.Length - 1) + " is required." : string.Empty;
            return rslt;
        }

        public void SetProjectCostCodeTemplate(string templatefilepath)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            DataTable result = new DataTable();
            result.Columns.Add("CostCodeID");
            result.Columns.Add("Description");
            result.Columns.Add("UOM");
            result.Columns.Add("Estimated Quantity");
            result.Columns.Add("Estimated Man-hour");
            // Get connection string

            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ProjectId", userinfo.CurrentProjectId)); //test

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListCostCodeForTemplate", parameters.ToArray());

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                result.Rows.Add(r.ItemArray);
            }

            //if (!System.IO.Directory.Exists(templatefilepath))
            //{
            //    System.IO.Directory.CreateDirectory(templatefilepath);
            //}

            //Export2Excel.ConvertExcelfromData(result, "projectcostcode_template.xlsx", templatefilepath);
        }

        #endregion

        #region ProjectCostCode

        public SigmaResultType GetProjectCostCode(string CostCode)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@CostCode", CostCode),
                    new SqlParameter("@ProjectId", userinfo.CurrentProjectId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetProjectCostCode", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListProjectCostCode(string offset, string max, List<string> s_option, List<string> s_key, string o_option, string o_desc)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
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

            parameters.Add(new SqlParameter("@ProjectId", userinfo.CurrentProjectId));



            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListProjectCostCode", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListProjectCostCodeForMap(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@UomCode", (s_option == "UomCode" ? s_key : null)));
            parameters.Add(new SqlParameter("@EstimatedQty", (s_option == "EstimatedQty" ? s_key : null)));
            parameters.Add(new SqlParameter("@EstimatedManhour", (s_option == "EstimatedManhour" ? s_key : null)));

            parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
            parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));

            parameters.Add(new SqlParameter("@SortColumn", o_option));
            parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));


            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListProjectCostCodeForMap", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddProjectCostCode(TypeProjectCostCode objProjectCostCode)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            SqlParameter[] parameters = new SqlParameter[] {
					new SqlParameter("@CostCodeId", objProjectCostCode.CostCodeId),
					new SqlParameter("@ProjectId", AuthMgr.GetUserInfo().CurrentProjectId),
					new SqlParameter("@UomCode", objProjectCostCode.UomCode),
					new SqlParameter("@EstimatedQty", objProjectCostCode.EstimatedQty),
					new SqlParameter("@EstimatedManhour", objProjectCostCode.EstimatedManhour),
					new SqlParameter("@CreatedBy", AuthMgr.GetUserInfo().SigmaUserId),
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddProjectCostCode", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType AddProjectCostCodeByTemplate(TypeProjectCostCode objProjectCostCode)
        {

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CostCode", objProjectCostCode.CostCode));
            paramList.Add(new SqlParameter("@ProjectId", AuthMgr.GetUserInfo().CurrentProjectId));
            paramList.Add(new SqlParameter("@UomName", objProjectCostCode.UomName));
            paramList.Add(new SqlParameter("@EstimatedQty", objProjectCostCode.EstimatedQty));
            paramList.Add(new SqlParameter("@EstimatedManhour", objProjectCostCode.EstimatedManhour));
            paramList.Add(new SqlParameter("@CreatedBy", AuthMgr.GetUserInfo().SigmaUserId));


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddProjectCostCodeByTemplate", paramList.ToArray());
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType UpdateProjectCostCode(TypeProjectCostCode objProjectCostCode)
        {
          
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ProjectCostCodeId", objProjectCostCode.ProjectCostCodeId),
					new SqlParameter("@CostCodeId", objProjectCostCode.CostCodeId),
					new SqlParameter("@ProjectId", AuthMgr.GetUserInfo().CurrentProjectId),
					new SqlParameter("@UomCode", objProjectCostCode.UomCode),
					new SqlParameter("@EstimatedQty", objProjectCostCode.EstimatedQty),
					new SqlParameter("@EstimatedManhour", objProjectCostCode.EstimatedManhour),
					new SqlParameter("@UpdatedBy", AuthMgr.GetUserInfo().SigmaUserId),
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateProjectCostCode", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType RemoveProjectCostCode(TypeProjectCostCode objProjectCostCode)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ProjectCostCodeId", objProjectCostCode.ProjectCostCodeId)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveProjectCostCode", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType MultiProjectCostCode(List<TypeProjectCostCode> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypeProjectCostCode anObj in listObj)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            AddProjectCostCode(anObj);
                            break;
                        case "U":
                            UpdateProjectCostCode(anObj);
                            break;
                        case "D":
                            RemoveProjectCostCode(anObj);
                            break;
                    }
                }

                scope.Complete();
                result.IsSuccessful = true;
            }

            return result;
        }

        public SigmaResultType ImportProjectCostCodeFromExcel(string filePath, string exportfilepath)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            DataTable dt = new DataTable();
            DataTable tmpDt = new DataTable();
            SigmaResultType result = new SigmaResultType();

            dt = Element.Shared.Common.ImportHelper.ImportWorkSheet(filePath, true);

            DataTable tmpdt = new DataTable();
            tmpdt = dt.Copy();
            tmpdt.Rows.Clear();
            tmpdt.Columns.Add("Fail reason");

            int failCnt = 0;

            foreach (DataRow r in dt.Rows)
            {
                TypeProjectCostCode obj = new TypeProjectCostCode();
                obj.CostCode = r[0].ToString();
                obj.UomName = r[2].ToString();

                obj.ProjectId = userinfo.CurrentProjectId;
                obj.CreatedBy = userinfo.SigmaUserId;

                if (string.IsNullOrEmpty(GetFailreasonForRequiredProjectCostCode(r)))
                {
                    if (!string.IsNullOrEmpty(r[3].ToString()))
                        obj.EstimatedQty = Convert.ToDecimal(r[3].ToString());
                    if (!string.IsNullOrEmpty(r[4].ToString()))
                        obj.EstimatedManhour = Convert.ToDecimal(r[4].ToString());

                    SigmaResultType rst = AddProjectCostCodeByTemplate(obj);

                    if (!rst.IsSuccessful)
                    {
                        tmpdt.Rows.Add(r.ItemArray);
                        tmpdt.Rows[tmpdt.Rows.Count - 1]["Fail reason"] = rst.ErrorMessage.ToString();
                        failCnt++;
                    }
                }
                else
                {
                    tmpdt.Rows.Add(r.ItemArray);
                    tmpdt.Rows[tmpdt.Rows.Count - 1]["Fail reason"] = GetFailreasonForRequiredProjectCostCode(r);
                    failCnt++;
                }
            }
            TypeImportHistory ImportHistory = new TypeImportHistory();
            ImportHistory.ImportCategory = "ProjectCostCode";
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

        private string GetFailreasonForRequiredProjectCostCode(DataRow r)
        {
            string rslt = string.Empty;
            string rslt2 = string.Empty;
            if (string.IsNullOrEmpty(r[2].ToString()))
                rslt += "UOM,";
            if (string.IsNullOrEmpty(r[3].ToString()))
                rslt += "Estimated Quantity,";
            else if (!IsCanConvert(r[3].ToString()))
                rslt2 += "Estimated Quantity,";
            if (string.IsNullOrEmpty(r[4].ToString()))
                rslt += "Estimated Man-hour,";
            else if (!IsCanConvert(r[4].ToString()))
                rslt2 += "Estimated Man-hour,";

            rslt = rslt.Length > 0 ? rslt.Substring(0, rslt.Length - 1) + " is required." : string.Empty;
            rslt2 = rslt2.Length > 0 ? rslt2.Substring(0, rslt2.Length - 1) + " is not a valid decimal." : string.Empty;

            return rslt + (string.IsNullOrEmpty(rslt) || string.IsNullOrEmpty(rslt2) ? "" : "/") + rslt2;
        }

        private bool IsCanConvert(string org)
        {
            bool canConvert = false;
            decimal trg = 0;
            canConvert = decimal.TryParse(org, out trg);
            return canConvert;
        }

        #endregion

        #region ClientCostCode

        public SigmaResultType GetClientCostCode(string clientCostCodeId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ClientCostCodeId", clientCostCodeId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetClientCostCode", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListClientCostCode(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ClientCostCode", (s_option == "ClientCostCode" ? s_key : null)));
            parameters.Add(new SqlParameter("@ClientCostCodeName", (s_option == "ClientCostCodeName" ? s_key : null)));

            parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
            parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));

            parameters.Add(new SqlParameter("@SortColumn", o_option));
            parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));


            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListClientCostCode", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddClientCostCode(TypeClientCostCode objClientCostCode)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            objClientCostCode.ClientCompanyId = userinfo.ClientCompanyId;
            objClientCostCode.CreatedBy = userinfo.SigmaUserId;

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ClientCompanyId", objClientCostCode.ClientCompanyId));
            paramList.Add(new SqlParameter("@ClientCostCode", objClientCostCode.ClientCostCode));
            paramList.Add(new SqlParameter("@ClientCostCodeName", objClientCostCode.ClientCostCodeName));
            paramList.Add(new SqlParameter("@ProjectId", AuthMgr.GetUserInfo().CurrentProjectId));
            paramList.Add(new SqlParameter("@CreatedBy", objClientCostCode.CreatedBy));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddClientCostCode", paramList.ToArray());
                if (result.AffectedRow > 0)
                {
                    result.IsSuccessful = true;
                    result.ScalarValue = (int)outParam.Value;
                }
                else
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "CostCode is duplicated";
                }
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType UpdateClientCostCode(TypeClientCostCode objClientCostCode)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            objClientCostCode.ClientCompanyId = userinfo.ClientCompanyId;
            objClientCostCode.UpdatedBy = userinfo.SigmaUserId;

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ClientCostCodeId", objClientCostCode.ClientCostCodeId),
					new SqlParameter("@ClientCompanyId", objClientCostCode.ClientCompanyId),
					new SqlParameter("@ClientCostCode", objClientCostCode.ClientCostCode),
					new SqlParameter("@ClientCostCodeName", objClientCostCode.ClientCostCodeName),
					new SqlParameter("@UpdatedBy", objClientCostCode.UpdatedBy),
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateClientCostCode", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType RemoveClientCostCode(TypeClientCostCode objClientCostCode)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ClientCostCodeId", objClientCostCode.ClientCostCodeId)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveClientCostCode", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType MultiClientCostCode(List<TypeClientCostCode> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypeClientCostCode anObj in listObj)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            AddClientCostCode(anObj);
                            break;
                        case "U":
                            UpdateClientCostCode(anObj);
                            break;
                        case "D":
                            RemoveClientCostCode(anObj);
                            break;
                    }
                }

                scope.Complete();
                result.IsSuccessful = true;
            }

            return result;
        }

        public SigmaResultType ImportClientCostCodeFromExcel(string filePath, string exportfilepath)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            DataTable dt = new DataTable();
            DataTable tmpDt = new DataTable();
            SigmaResultType result = new SigmaResultType();

            dt = Element.Shared.Common.ImportHelper.ImportWorkSheet(filePath, true);

            DataTable tmpdt = new DataTable();
            tmpdt = dt.Copy();
            tmpdt.Rows.Clear();
            tmpdt.Columns.Add("Fail reason");

            int failCnt = 0;

            foreach (DataRow r in dt.Rows)
            {
                TypeClientCostCode obj = new TypeClientCostCode();
                obj.ClientCostCode = r[0].ToString();
                obj.ClientCostCodeName = r[1].ToString();
                obj.ClientCompanyId = userinfo.ClientCompanyId;
                obj.CreatedBy = userinfo.SigmaUserId;

                if (string.IsNullOrEmpty(GetFailreasonForRequiredClientCostCode(r)))
                {
                    SigmaResultType rst = AddClientCostCode(obj);

                    if (!rst.IsSuccessful)
                    {
                        tmpdt.Rows.Add(r.ItemArray);
                        tmpdt.Rows[tmpdt.Rows.Count - 1]["Fail reason"] = rst.ErrorMessage.ToString();
                        failCnt++;
                    }
                }
                else
                {
                    tmpdt.Rows.Add(r.ItemArray);
                    tmpdt.Rows[tmpdt.Rows.Count - 1]["Fail reason"] = GetFailreasonForRequiredClientCostCode(r);
                    failCnt++;
                }
            }
            TypeImportHistory ImportHistory = new TypeImportHistory();
            ImportHistory.ImportCategory = "ClientCostCode";
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

        private string GetFailreasonForRequiredClientCostCode(DataRow r)
        {
            string rslt = string.Empty;
            if (string.IsNullOrEmpty(r[0].ToString()))
                rslt += "CostCode,";
            if (string.IsNullOrEmpty(r[1].ToString()))
                rslt += "Description,";

            rslt = rslt.Length > 0 ? rslt.Substring(0, rslt.Length - 1) + " is required." : string.Empty;
            return rslt;
        }


        #endregion

        #region CostCodeMap

        public SigmaResultType GetCostCodeMap(string costCodeMapId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@CostCodeMapId", costCodeMapId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetCostCodeMap", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListCostCodeMap(string offset, string max, List<string> s_option, List<string> s_key, string o_option, string o_desc)
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
            parameters.Add(new SqlParameter("@ProjectId", AuthMgr.GetUserInfo().CurrentProjectId));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListCostCodeMap", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddCostCodeMap(TypeCostCodeMap objCostCodeMap)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ClientCostCodeId", objCostCodeMap.ClientCostCodeId));
            paramList.Add(new SqlParameter("@ProjectCostCodeId", objCostCodeMap.ProjectCostCodeId));
            paramList.Add(new SqlParameter("@ProjectId", AuthMgr.GetUserInfo().CurrentProjectId));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddCostCodeMap", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                scope.Complete();

            }
            result.IsSuccessful = true;
            return result;
        }

        public SigmaResultType UpdateCostCodeMap(TypeCostCodeMap objCostCodeMap)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
					new SqlParameter("@ClientCostCodeId", objCostCodeMap.ClientCostCodeId),
					new SqlParameter("@ProjectCostCodeId", objCostCodeMap.ProjectCostCodeId)
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateCostCodeMap", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType RemoveCostCodeMap(TypeCostCodeMap objCostCodeMap)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@CostCodeMapId", objCostCodeMap.CostCodeMapId)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveCostCodeMap", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType RemoveCostCodeMapALL()
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ProjectId", AuthMgr.GetUserInfo().CurrentProjectId)
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveCostCodeMapALL", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType MultiCostCodeMap(List<TypeCostCodeMap> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            RemoveCostCodeMapALL();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                foreach (TypeCostCodeMap anObj in listObj)
                {
                    AddCostCodeMap(anObj);
                }
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        #endregion

    }
}
