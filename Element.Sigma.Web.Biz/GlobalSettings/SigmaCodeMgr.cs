using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.MTO;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using System.Xml.Linq;
using System.Collections.Specialized;
using Element.Sigma.Web.Biz.Types.Auth;
using Element.Sigma.Web.Biz.Auth;

namespace Element.Sigma.Web.Biz.GlobalSettings
{
    public class SigmaCodeMgr
    {
        #region SigmaCode

        public SigmaResultType GetSigmaCode(string code, string codeCategory)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Code", code),
                new SqlParameter("@CodeCategory", codeCategory)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetSigmaCode", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListSigmaCode(NameValueCollection queryParams)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> paramList = new List<SqlParameter>();

            string max = queryParams["max"];
            string offset = queryParams["offset"];
            string o_option = queryParams["o_option"];
            string o_desc = queryParams["o_desc"];
            string s_option = queryParams["s_option"];
            string s_key = queryParams["s_key"];

            paramList.Add(new SqlParameter("@MaxNumRows", (max == null ? 10 : int.Parse(max))));
            paramList.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));
            paramList.Add(new SqlParameter("@SortColumn", o_option));
            paramList.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));
            paramList.Add(new SqlParameter("@Code", (s_option == "Code" ? s_key : null)));
            paramList.Add(new SqlParameter("@CodeCategory", (s_option == "CodeCategory" ? s_key : null)));
            paramList.Add(new SqlParameter("@CodeName", (s_option == "CodeName" ? s_key : null)));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListSigmaCode", paramList.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddSigmaCode(TypeSigmaCode objSigmaCode)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();
            
            if (!(string.IsNullOrEmpty(objSigmaCode.CodeName))
                && !(string.IsNullOrEmpty(objSigmaCode.CodeCategory))
            )
            {
                List<SqlParameter> paramList = new List<SqlParameter>();
                paramList.Add(new SqlParameter("@Code", objSigmaCode.CodeCategory + objSigmaCode.CodeName.ToUpper().Replace(" ", "_")));
                paramList.Add(new SqlParameter("@CodeCategory", objSigmaCode.CodeCategory.Trim()));
                paramList.Add(new SqlParameter("@CodeName", objSigmaCode.CodeName.Trim()));
                paramList.Add(new SqlParameter("@CodeShortName", objSigmaCode.CodeShortName.Trim()));
                paramList.Add(new SqlParameter("@RefChar", objSigmaCode.RefChar));
                paramList.Add(new SqlParameter("@RefNo", Utilities.ToInt32(objSigmaCode.RefNo)));
                paramList.Add(new SqlParameter("@Description", objSigmaCode.Description.Trim()));
                paramList.Add(new SqlParameter("@IsActive", objSigmaCode.IsActive));
                paramList.Add(new SqlParameter("@SortOrder", objSigmaCode.SortOrder));
                paramList.Add(new SqlParameter("@CreatedBy", userinfo.SigmaUserId.Trim()));
                SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
                outParam.Direction = ParameterDirection.Output;
                paramList.Add(outParam);

                using (scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddSigmaCode", paramList.ToArray());
                    result.IsSuccessful = true;
                    //result.ScalarValue = (int)outParam.Value;

                    scope.Complete();
                }
            }
            else
            {
                result.AffectedRow = -1;
                result.ErrorCode = "GlobalSetting0001";
                result.ErrorMessage = "Validation";
                result.IsSuccessful = false;
            }

            return result;
        }

        public SigmaResultType UpdateSigmaCode(TypeSigmaCode objSigmaCode)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            if (!(string.IsNullOrEmpty(objSigmaCode.CodeName))
                && !(string.IsNullOrEmpty(objSigmaCode.CodeCategory))
            )
            {
                // Compose parameters
                SqlParameter[] parameters = new SqlParameter[] {
				    new SqlParameter("@Code", objSigmaCode.Code),
                    new SqlParameter("@CodeCategory", objSigmaCode.CodeCategory.Trim()),
                    new SqlParameter("@CodeName", objSigmaCode.CodeName.Trim()),
				    new SqlParameter("@CodeShortName", objSigmaCode.CodeShortName),
				    new SqlParameter("@RefChar", objSigmaCode.RefChar),
				    new SqlParameter("@RefNo", Utilities.ToInt32(objSigmaCode.RefNo)),
				    new SqlParameter("@Description", objSigmaCode.Description.Trim()),
				    new SqlParameter("@IsActive", objSigmaCode.IsActive),
				    new SqlParameter("@SortOrder", objSigmaCode.SortOrder),
				    new SqlParameter("@UpdatedBy", userinfo.SigmaUserId.Trim())
                };

                using (scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateSigmaCode", parameters);
                    result.IsSuccessful = true;

                    scope.Complete();
                }
            }
            else
            {
                result.AffectedRow = -1;
                result.ErrorCode = "GlobalSetting0001";
                result.ErrorMessage = "Validation";
                result.IsSuccessful = false;
            }

            return result;
        }

        public SigmaResultType RemoveSigmaCode(TypeSigmaCode objSigmaCode)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@Code", objSigmaCode.Code.Trim()),
                new SqlParameter("@CodeCategory", objSigmaCode.CodeCategory.Trim())
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveSigmaCode", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType MultiSigmaCode(List<TypeSigmaCode> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var affectCount = 0;

                foreach (TypeSigmaCode item in listObj)
                {
                    switch (item.SigmaOperation)
                    {
                        case SigmaOperation.DELETE:
                            affectCount += RemoveSigmaCode(item).AffectedRow;
                            break;
                    }
                }
                result.AffectedRow = affectCount;
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public DataSet ListSigmaCodeByCodeCategory(string codeName, string codeCategory)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CodeName", codeName),
                new SqlParameter("@CodeCategory", codeCategory)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListSigmaCodeByCodeCategory", parameters);

            return ds;
        }

        public DataSet ListSigmaCodeForEquipment(string codeCategory)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CodeCategory", codeCategory)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListSigmaCodeForEquipment", parameters);

            return ds;
        }

        #endregion SigmaCode

        #region SigmaCodeCategory

        public SigmaResultType GetSigmaCodeCategory(string codeCategory)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@codeCategory", codeCategory)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetSigmaCodeCategory", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListSigmaCodeCategory(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            //parameters.Add(new SqlParameter("@CodeCategory", (s_option == "CodeCategory" ? s_key : null)));
            //parameters.Add(new SqlParameter("@CategoryName", (s_option == "CategoryName" ? s_key : null)));

            parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
            parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));

            parameters.Add(new SqlParameter("@SortColumn", o_option));
            parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));


            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListSigmaCodeCategory", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddSigmaCodeCategory(TypeSigmaCodeCategory objSigmaCodeCategory)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CategoryName", objSigmaCodeCategory.CategoryName));
            paramList.Add(new SqlParameter("@CategoryDescription", objSigmaCodeCategory.CategoryDescription));
            paramList.Add(new SqlParameter("@ParentCodeCategory", objSigmaCodeCategory.ParentCodeCategory));
            paramList.Add(new SqlParameter("@CreatedBy", objSigmaCodeCategory.CreatedBy));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddSigmaCodeCategory", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                scope.Complete();

            }

            return result;
        }
        
        public SigmaResultType UpdateSigmaCodeCategory(TypeSigmaCodeCategory objSigmaCodeCategory)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
					new SqlParameter("@CategoryName", objSigmaCodeCategory.CategoryName),
					new SqlParameter("@CategoryDescription", objSigmaCodeCategory.CategoryDescription),
					new SqlParameter("@ParentCodeCategory", objSigmaCodeCategory.ParentCodeCategory),
					new SqlParameter("@CreatedBy", objSigmaCodeCategory.CreatedBy),
					new SqlParameter("@UpdatedBy", objSigmaCodeCategory.UpdatedBy),
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateSigmaCodeCategory", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }
        
        public SigmaResultType RemoveSigmaCodeCategory(TypeSigmaCodeCategory objSigmaCodeCategory)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@codeCategory", objSigmaCodeCategory.CodeCategory)
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveSigmaCodeCategory", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType MultiSigmaCodeCategory(List<TypeSigmaCodeCategory> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypeSigmaCodeCategory anObj in listObj)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            AddSigmaCodeCategory(anObj);
                            break;
                        case "U":
                            UpdateSigmaCodeCategory(anObj);
                            break;
                        case "D":
                            RemoveSigmaCodeCategory(anObj);
                            break;
                    }
                }

                scope.Complete();
            }

            return result;
        }

        public DataSet ListSigmaCodeCategoryByParentCodeCategory(string parentCodeCategory, string categoryName)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ParentCodeCategory", parentCodeCategory),
                new SqlParameter("@CategoryName", categoryName)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetSigmaCodeCategoryByParentCodeCategory", parameters);

            // return
            return ds;
        }

        #endregion SigmaCodeCategory

    }
}
