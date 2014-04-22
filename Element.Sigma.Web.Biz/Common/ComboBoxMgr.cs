using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Transactions;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.Auth;
using Element.Sigma.Web.Biz.Auth;
using System;

namespace Element.Sigma.Web.Biz.Common
{
    public class ComboBoxMgr
    {
        #region Material Library
        public SigmaResultType GetDisciplineCombo()
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            string CodeCategory = "DISCIPLINE";
            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CodeCategory", CodeCategory)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetDisciplineCombo", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
			//result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetDisciplineComboByProjectId(string projectId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            string CodeCategory = "DISCIPLINE";
            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CodeCategory", CodeCategory),
                new SqlParameter("@ProjectId", Utilities.ToInt32(projectId.Trim()))
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetDisciplineComboByProjectId", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetCwpCombo()
        {
            SigmaResultType result = new SigmaResultType();
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ProjectId", userinfo.CurrentProjectId),
                new SqlParameter("@DisciplineCode", null)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetCwpByComobo", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetIwpCombo(string cwpId)
        {
            SigmaResultType result = new SigmaResultType();
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CwpId", Convert.ToInt32(cwpId))
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetIwpByCombo", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetDrawingNumberCombo(int cwpId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CwpId", cwpId),
                new SqlParameter("@ProjectId", userinfo.CurrentProjectId)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetDrawingNumberComboByCWPId", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetTaskCategoryCombo(string disciplineCode)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@DisciplineCode", disciplineCode)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetTaskCategoryComboByDiscipline", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetTaskCategoryByCwpIdCombo(string CwpId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CwpId", CwpId)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetTaskCategoryComboByCwpId", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetProgressStepCombo(List<string> s_option, List<string> s_key)
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

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetProgressStepCombo", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetProgressTypeCombo(string disciplineCode)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@DisciplineCode", disciplineCode)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetProgressTypeComboByDiscipline", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetProgressTypeComboByCwpId(string cwpId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CwpId", cwpId)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetProgressTypeComboByCwpId", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetTaskTypeCombo(string taskCategoryId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@TaskCategoryId",  int.Parse(taskCategoryId))
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetTaskTypeComboByTaskCategory", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        #endregion Material Library

        #region Common
        /// <summary>
        /// Set CostCode Combo box
        /// </summary>
        /// <returns></returns>
        public SigmaResultType GetCostCodeCombo()
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            SigmaResultType result = new SigmaResultType();
            string connStr = ConnStrHelper.getDbConnString();
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@CompanyId", userinfo.CompanyId)
            };
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetCostCodeCombo", parameters);
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.IsSuccessful = true;
            return result;
        }

        /// <summary>
        /// Set CustomFieldCombo
        /// </summary>
        /// <returns></returns>
        public SigmaResultType GetCustomFieldCombo()
        {
            SigmaResultType result = new SigmaResultType();
            string connStr = ConnStrHelper.getDbConnString();
            SqlParameter[] parameters = new SqlParameter[] {};
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetCustomFieldCombo", parameters);
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.IsSuccessful = true;
            return result;
        }


        public SigmaResultType GetSigmaCodeCombo(string codeCategory)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CodeCategory", codeCategory)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetSigmaCodeCombo", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetCompanyCombo()
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CompanyId", userinfo.CompanyId)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetCompanyCombo", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetCompanyAllCombo()
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetCompanyAllCombo", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetCompanyByCompanyTypeCodeCombo(string companyTypeCode)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CompanyTypeCode", companyTypeCode)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetCompanyByCompanyTypeCodeCombo", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetCompanyTypeCombo()
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetCompanyTypeCombo", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetSigmaRoleCombo()
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetSigmaRoleCombo", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetSigmaUserCombo()
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ProjectId", userinfo.CurrentProjectId)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetSigmaUserCombo", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetSigmaUserForProjectCombo()
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetSigmaUserForProjectCombo", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetDrawingType()
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetDrawingTypeCombo", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        #endregion

        #region Equipment

        public SigmaResultType GetEquipmentCodeCombo(string codeCategory)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CodeCategory", codeCategory)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetEquipmentCodeCombo", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetEquipmentThirdLevelCombo(string codeCategory)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CodeCategory", codeCategory)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetEquipmentThirdLevelCombo", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        #endregion Equipment

        #region Project Add

        public SigmaResultType GetCountryCombo()
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                //new SqlParameter("@ProjectId", projectId)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetCountryCombo", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetCountyCombo(string country)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Country", country)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetCountyCombo", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetProjectCombo()
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@SigmaUserId", userinfo.SigmaUserId)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetProjectCombo", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetDefaultProjectCombo()
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@SigmaUserId", userinfo.SigmaUserId)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetDefaultProjectCombo", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            //result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        #endregion Project Add



    }
}
