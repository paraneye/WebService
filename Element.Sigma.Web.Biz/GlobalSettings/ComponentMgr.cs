using System;
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
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.Types.MTO;
using Element.Sigma.Web.Biz.Types.Auth;
using Element.Sigma.Web.Biz.Auth;

namespace Element.Sigma.Web.Biz.GlobalSettings
{
    public class ComponentMgr
    {

        /// <summary>
        /// Import MTO 메뉴얼 등록시  
        /// </summary>
        /// <param name="objComponent"></param>
        /// <returns></returns>
        public SigmaResultType AddComponetInfo(TypeComponent objComponent)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();
            SigmaResultType resultComponent = new SigmaResultType();
            ComponentCustomFieldMgr ComCustomFieldMgr = new ComponentCustomFieldMgr();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                if (objComponent.ComponentId > 0)
                {
                    resultComponent = UpdateComponent(objComponent);
                }
                else
                {
                    resultComponent = AddComponent(objComponent);

                    objComponent.ComCustomField.ForEach(item => item.ComponentId = resultComponent.ScalarValue);
                }

                if (resultComponent.IsSuccessful && objComponent.ComCustomField.Count > 0)
                {
                    ComponentCustomFieldMgr comcustomfieldMgr = new ComponentCustomFieldMgr();
                    TypeComponentCustomField cutomobj = new TypeComponentCustomField();
                    cutomobj.ComponentId = objComponent.ComponentId;
                    comcustomfieldMgr.RemoveComponentCustomField(cutomobj);

                    foreach (var item in objComponent.ComCustomField)
                    {
                        if (item.CustomFieldId == 0)
                        {
                            TypeCustomField obj = SetTypeCustomFieldObj(item);
                            CustomFieldMgr customFieldMtr = new CustomFieldMgr();
                            obj = customFieldMtr.GetCustomField(obj);
                            item.CustomFieldId = obj.CustomFieldId;
                        }

                        switch (item.SigmaOperation)
                        {
                            case SigmaOperation.INSERT:
                                ComCustomFieldMgr.AddComponentCustomField(item);
                                break;
                            case SigmaOperation.UPDATE:
                                ComCustomFieldMgr.UpdateComponentCustomField(item);
                                break;
                            case SigmaOperation.DELETE:
                                ComCustomFieldMgr.RemoveComponentCustomField(item);
                                break;
                        }
                    }
                }

                result.AffectedRow = resultComponent.AffectedRow;
                result.ScalarValue = resultComponent.ScalarValue;
                result.IsSuccessful = true;

                scope.Complete();
            }
            return result;
        }

        private TypeCustomField SetTypeCustomFieldObj(TypeComponentCustomField obj)
        {
            TypeCustomField rtn = new TypeCustomField();
            rtn.FieldName = obj.FieldName;
            rtn.IsDisplayable = obj.IsDisplayable;
            return rtn;
        }

        public SigmaResultType GetComponent(string componentId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ComponentId", componentId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetComponent", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }
        public SigmaResultType ListComponent(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();


            parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
            parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));

            parameters.Add(new SqlParameter("@SortColumn", o_option));
            parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));


            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListComponent", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }
        public SigmaResultType AddComponent(TypeComponent objComponent)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@MaterialId", objComponent.MaterialId));
            paramList.Add(new SqlParameter("@CwpId", objComponent.CwpId));
            paramList.Add(new SqlParameter("@DrawingId", objComponent.DrawingId));
            paramList.Add(new SqlParameter("@ScheduledWorkItemId", objComponent.ScheduledWorkItemId));
            paramList.Add(new SqlParameter("@TagNumber", objComponent.TagNumber));
            paramList.Add(new SqlParameter("@ComponentProgressRatio", objComponent.ComponentProgressRatio));
            paramList.Add(new SqlParameter("@CompletedPercent", objComponent.CompletedPercent));
            paramList.Add(new SqlParameter("@Qty", objComponent.Qty));
            paramList.Add(new SqlParameter("@EstimatedManhour", Convert.ToDecimal(objComponent.EstimatedManhour)));
            paramList.Add(new SqlParameter("@Description", objComponent.Description));
            paramList.Add(new SqlParameter("@IsoLineNo", objComponent.IsoLineNo));
            paramList.Add(new SqlParameter("@EngTagNumber", objComponent.EngTagNumber));
            if (objComponent.ImportHistoryId == 0)
                paramList.Add(new SqlParameter("@ImportHistoryId", DBNull.Value));
            else
                paramList.Add(new SqlParameter("@ImportHistoryId", Utilities.ToInt32(objComponent.ImportHistoryId.ToString().Trim())));

            paramList.Add(new SqlParameter("@CreatedBy", userinfo.SigmaUserId));
            SqlParameter outParam = new SqlParameter("@NewId", SqlDbType.Int);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddComponent", paramList.ToArray());
                result.IsSuccessful = true;
                result.ScalarValue = (int)outParam.Value;
                scope.Complete();

            }

            return result;
        }
        public SigmaResultType UpdateComponent(TypeComponent objComponent)
        {
            TransactionScope scope = null;
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ComponentId", objComponent.ComponentId));
            paramList.Add(new SqlParameter("@MaterialId", objComponent.MaterialId));
            paramList.Add(new SqlParameter("@CwpId", objComponent.CwpId));
            paramList.Add(new SqlParameter("@DrawingId", objComponent.DrawingId));
            paramList.Add(new SqlParameter("@ScheduledWorkItemId", objComponent.ScheduledWorkItemId));
            paramList.Add(new SqlParameter("@TagNumber", objComponent.TagNumber));
            paramList.Add(new SqlParameter("@ComponentProgressRatio", objComponent.ComponentProgressRatio));
            paramList.Add(new SqlParameter("@CompletedPercent", objComponent.CompletedPercent));
            paramList.Add(new SqlParameter("@Qty", objComponent.Qty));
            paramList.Add(new SqlParameter("@EstimatedManhour", Convert.ToDecimal(objComponent.EstimatedManhour)));
            paramList.Add(new SqlParameter("@Description", objComponent.Description));
            paramList.Add(new SqlParameter("@IsoLineNo", objComponent.IsoLineNo));
            paramList.Add(new SqlParameter("@EngTagNumber", objComponent.EngTagNumber));
            if (objComponent.ImportHistoryId == 0)
                paramList.Add(new SqlParameter("@ImportHistoryId", DBNull.Value));
            else
                paramList.Add(new SqlParameter("@ImportHistoryId", Utilities.ToInt32(objComponent.ImportHistoryId.ToString().Trim())));

            paramList.Add(new SqlParameter("@UpdatedBy", userinfo.SigmaUserId));

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateComponent", paramList.ToArray());
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }
        public SigmaResultType RemoveComponent(TypeComponent objComponent)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ComponentId", objComponent.ComponentId)
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveComponent", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }
        public SigmaResultType MultiComponent(List<TypeComponent> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypeComponent anObj in listObj)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            AddComponent(anObj);
                            break;
                        case "U":
                            UpdateComponent(anObj);
                            break;
                        case "D":
                            RemoveComponent(anObj);
                            break;
                    }
                }
                
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        /// <summary>
        /// 2014-03-02 
        /// Delete MTO
        /// </summary>
        /// <param name="objComponent"></param>
        /// <returns></returns>
        public SigmaResultType DeleteMTO(TypeComponent objComponent)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ComponentId", objComponent.ComponentId)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveComponentCustomFieldProgress", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

    }
}
