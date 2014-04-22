using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.ProjectSettings;
using Element.Sigma.Web.Biz.Auth;
using Element.Sigma.Web.Biz.Types.Auth;

namespace Element.Sigma.Web.Biz.ProjectSettings
{
    public class CWAMgr
    {
        #region CWA

        public SigmaResultType GetCWA(string cwaId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CwaId", Utilities.ToInt32(cwaId.Trim()))
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetCWA", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListCWA()
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();
            
            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ProjectId", Utilities.ToInt32(userinfo.CurrentProjectId.ToString().Trim())));

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListCwaByProjectId", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddCWA(TypeCWA objCWA)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ProjectId", Utilities.ToInt32(userinfo.CurrentProjectId.ToString().Trim())));
            paramList.Add(new SqlParameter("@Name", objCWA.Name.Trim()));
            paramList.Add(new SqlParameter("@Area", objCWA.Area));
            paramList.Add(new SqlParameter("@Description", objCWA.Description.Trim()));
            paramList.Add(new SqlParameter("@CreatedBy", userinfo.SigmaUserId.Trim()));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddCWA", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType UpdateCWA(TypeCWA objCWA)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CwaId", Utilities.ToInt32(objCWA.CwaId.ToString().Trim())),
                new SqlParameter("@ProjectId", Utilities.ToInt32(userinfo.CurrentProjectId.ToString().Trim())),
                new SqlParameter("@Name", objCWA.Name.Trim()),
                new SqlParameter("@Area", objCWA.Area),
                new SqlParameter("@Description", objCWA.Description.Trim()),
                new SqlParameter("@UpdatedBy", userinfo.SigmaUserId.Trim())
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateCWA", parameters);
                result.IsSuccessful = true;

                scope.Complete();
            }

            return result;
        }

        public SigmaResultType RemoveCWA(TypeCWA objCWA)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CwaId", Utilities.ToInt32(objCWA.CwaId.ToString().Trim()))
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveCWA", parameters);
                result.IsSuccessful = true;

                scope.Complete();
            }

            return result;
        }

        public SigmaResultType MultiCWA(List<TypeCWA> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var affectCount = 0;

                foreach (TypeCWA item in listObj)
                {
                    switch (item.SigmaOperation)
                    {
                        case SigmaOperation.DELETE :
                            RemoveCWA(item);
                            break;
                    }
                }
                result.AffectedRow = affectCount;
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType AddCWAInfo(TypeCWA objCWA)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();
            SigmaResultType resultTypeCWA = new SigmaResultType();
            bool isCWP = true;

            if (objCWA.CWP.Count > 0)
            {
                var count = objCWA.CWP.Where(p => p.SigmaOperation == "C" && (p.CwpName.Trim() == "" || p.DisciplineCode.Trim() == "" || p.Description.Trim() == "")).Count();
                if (count > 0)
                    isCWP = false;
            }

            if (!(string.IsNullOrEmpty(objCWA.Name))
                && !(string.IsNullOrEmpty(objCWA.Description))
                && isCWP
            )
            {
                using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    if (objCWA.SigmaOperation == SigmaOperation.INSERT)
                    {
                        resultTypeCWA = AddCWA(objCWA);
                        objCWA.CWP.ForEach(item => item.CwaId = resultTypeCWA.ScalarValue);
                    }
                    else if (objCWA.SigmaOperation == SigmaOperation.UPDATE)
                    {
                        resultTypeCWA = UpdateCWA(objCWA);
                        objCWA.CWP.ForEach(item => item.CwaId = objCWA.CwaId);
                    }

                    if (resultTypeCWA.IsSuccessful && objCWA.CWP.Count > 0)
                    {
                        foreach (var item in objCWA.CWP)
                        {
                            switch (item.SigmaOperation)
                            {
                                case SigmaOperation.INSERT:
                                    AddCWP(item);
                                    break;
                                case SigmaOperation.UPDATE:
                                    UpdateCWP(item);
                                    break;
                                case SigmaOperation.DELETE:
                                    RemoveCWP(item);
                                    break;
                            }
                        }
                    }

                    result.AffectedRow = resultTypeCWA.AffectedRow;
                    result.ScalarValue = resultTypeCWA.ScalarValue;
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

        #endregion CWA

        #region CWP

        public SigmaResultType GetCWP(string cwpId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CwpId", Utilities.ToInt32(cwpId.ToString().Trim()))
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetCWP", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        //public SigmaResultType ListCWP(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
        //{
        //    SigmaResultType result = new SigmaResultType();

        //    // Get connection string
        //    string connStr = ConnStrHelper.getDbConnString();

        //    // Compose parameters
        //    List<SqlParameter> parameters = new List<SqlParameter>();

        //    parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
        //    parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));
        //    parameters.Add(new SqlParameter("@SortColumn", o_option));
        //    parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));

        //    // Get Data 
        //    DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListCWP", parameters.ToArray());

        //    // Convert to REST/JSON String
        //    result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
        //    result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
        //    result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
        //    result.IsSuccessful = true;
        //    // return
        //    return result;
        //}

        public SigmaResultType AddCWP(TypeCWP objCWP)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CwaId", Utilities.ToInt32(objCWP.CwaId.ToString().Trim())));
            paramList.Add(new SqlParameter("@CwpName", objCWP.CwpName.Trim()));
            paramList.Add(new SqlParameter("@DisciplineCode", objCWP.DisciplineCode.Trim()));
            paramList.Add(new SqlParameter("@Description", objCWP.Description.Trim()));
            paramList.Add(new SqlParameter("@CreatedBy", userinfo.SigmaUserId.Trim()));
            paramList.Add(new SqlParameter("@ProjectId", userinfo.CurrentProjectId));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddCWP", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;

                scope.Complete();
            }

            return result;
        }

        public SigmaResultType UpdateCWP(TypeCWP objCWP)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CwpId", Utilities.ToInt32(objCWP.CwpId.ToString().Trim())),
                new SqlParameter("@CwaId", Utilities.ToInt32(objCWP.CwaId.ToString().Trim())),
                new SqlParameter("@CwpName", objCWP.CwpName.Trim()),
                new SqlParameter("@DisciplineCode", objCWP.DisciplineCode.Trim()),
                new SqlParameter("@Description", objCWP.Description.Trim()),
                new SqlParameter("@UpdatedBy", userinfo.SigmaUserId.Trim()),
                new SqlParameter("@ProjectId", userinfo.CurrentProjectId)
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateCWP", parameters);
                result.IsSuccessful = true;

                scope.Complete();
            }

            return result;
        }

        public SigmaResultType RemoveCWP(TypeCWP objCWP)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CwpId", Utilities.ToInt32(objCWP.CwpId.ToString().Trim()))
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveCWP", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType MultiCWP(List<TypeCWP> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var affectCount = 0;

                foreach (TypeCWP item in listObj)
                {
                    switch (item.SigmaOperation)
                    {
                        case SigmaOperation.DELETE:
                            RemoveCWP(item);
                            break;
                    }
                }

                result.AffectedRow = affectCount;
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType GetCWPByCWAId(string cwaId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@CwaId", Utilities.ToInt32(cwaId.Trim()))
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetCWPByCWAId", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        #endregion CWP
    }
}
