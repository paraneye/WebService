using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Element.Sigma.Web.Biz.GlobalSettings
{
    public class CompanyMgr
    {

        public SigmaResultType GetCompany(string companyId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@companyId", companyId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetCompany", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }



        public SigmaResultType ListCompany(NameValueCollection queryParams)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@Name", (queryParams["Name"] != null ? queryParams["Name"] : null)));
            paramList.Add(new SqlParameter("@Address", (queryParams["Address"] != null ? queryParams["Address"] : null)));
            paramList.Add(new SqlParameter("@CompanyTypeCode", (queryParams["CompanyTypeCode"] != null ? queryParams["CompanyTypeCode"] : null)));

            string max = queryParams["max"];
            string offset = queryParams["offset"];
            string o_option = queryParams["o_option"];
            string o_desc = queryParams["o_desc"];

            paramList.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
            paramList.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));

            paramList.Add(new SqlParameter("@SortColumn", o_option));
            paramList.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));


            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListCompany", paramList.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }


        public SigmaResultType AddCompany(TypeCompany objCompany)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@Name", objCompany.Name));
            paramList.Add(new SqlParameter("@IsClient", objCompany.IsClient));
            paramList.Add(new SqlParameter("@Address", objCompany.Address));
            paramList.Add(new SqlParameter("@ContactName", objCompany.ContactName));
            paramList.Add(new SqlParameter("@ContactPhone", objCompany.ContactPhone));
            paramList.Add(new SqlParameter("@ContactFax", objCompany.ContactFax));
            paramList.Add(new SqlParameter("@ContactEmail", objCompany.ContactEmail));
            paramList.Add(new SqlParameter("@ContractTypeCode", objCompany.ContractTypeCode));
            paramList.Add(new SqlParameter("@CompanyTypeCode", objCompany.CompanyTypeCode));
            paramList.Add(new SqlParameter("@LogoFilePath", objCompany.LogoFilePath));
            paramList.Add(new SqlParameter("@CreatedBy", objCompany.CreatedBy));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddCompany", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                scope.Complete();

            }

            return result;
        }


        public SigmaResultType UpdateCompany(TypeCompany objCompany)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@CompanyId", objCompany.CompanyId));
            paramList.Add(new SqlParameter("@Name", objCompany.Name));
            paramList.Add(new SqlParameter("@IsClient", objCompany.IsClient));
            paramList.Add(new SqlParameter("@Address", objCompany.Address));
            paramList.Add(new SqlParameter("@ContactName", objCompany.ContactName));
            paramList.Add(new SqlParameter("@ContactPhone", objCompany.ContactPhone));
            paramList.Add(new SqlParameter("@ContactFax", objCompany.ContactFax));
            paramList.Add(new SqlParameter("@ContactEmail", objCompany.ContactEmail));
            paramList.Add(new SqlParameter("@ContractTypeCode", objCompany.ContractTypeCode));
            paramList.Add(new SqlParameter("@CompanyTypeCode", objCompany.CompanyTypeCode));
            paramList.Add(new SqlParameter("@LogoFilePath", objCompany.LogoFilePath));
            paramList.Add(new SqlParameter("@UpdatedBy", objCompany.UpdatedBy));

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateCompany", paramList.ToArray());
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType RemoveCompany(TypeCompany objCompany)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@companyId", objCompany.CompanyId)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveCompany", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }


        public SigmaResultType MultiCompany(List<TypeCompany> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypeCompany anObj in listObj)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            AddCompany(anObj);
                            break;
                        case "U":
                            UpdateCompany(anObj);
                            break;
                        case "D":
                            RemoveCompany(anObj);
                            break;
                    }
                }

                scope.Complete();
            }

            result.IsSuccessful = true;

            return result;
        }

    }
}
