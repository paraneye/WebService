using System;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.ServiceModel.Web;
using System.Collections.Generic;

using Element.Shared.Common;
using Element.Sigma.Web.Biz;
using Element.Sigma.Web.Biz.Common;
using Element.Sigma.Web.Biz.GlobalSettings;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.Types.ProjectData;
using Element.Sigma.Web.Biz.ProjectData;

using Element.Sigma.Web.Biz.Auth;
using Element.Sigma.Web.Biz.Types.Auth;


namespace Element.Sigma.Web.Biz.ProjectData
{
    public class DrawingMgr
    {
        public SigmaResultType GetDrawing(string DrawingId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@DrawingId", DrawingId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetDrawing", parameters);
            
            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType CountOrphanDrawing()
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@ResultMsg", SqlDbType.VarChar, 100) // sp에서 output 설정했을 경우
                };

            parameters[0].Direction = ParameterDirection.Output;

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetBindingDrawingOrphanCount", parameters);

            string resultMsg = (string)parameters[0].Value;

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = ds.Tables[0].Rows.Count;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListRefDrawing(string CWPName)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@CWPName", CWPName)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetDrawingNumberComboByCWPName", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = ds.Tables[0].Rows.Count;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType GetDrawingByNumber(string DrawingName)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@DrawingName", DrawingName)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetDrawingByNumber", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = ds.Tables[0].Rows.Count;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListDrawing(string offset, string max, List<string> s_option, List<string> s_key, string o_option, string o_desc)
        {
            SigmaResultType result = new SigmaResultType();
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

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
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListDrawing", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            if (result.AffectedRow < 1)
                result.ScalarValue = 0;
            else
                result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search

            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType DrawingViewer(string offset, string max, List<string> s_option, List<string> s_key, string o_option, string o_desc)
        {
            SigmaResultType result = new SigmaResultType();
            
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            for (int i = 0; i < s_option.Count; i++)
            {
                if(string.IsNullOrEmpty(s_key[i]))
                    parameters.Add(new SqlParameter(s_option[i], DBNull.Value));
                else
                    parameters.Add(new SqlParameter(s_option[i], s_key[i]));
            }

            parameters.Add(new SqlParameter("@ProjectId", Auth.AuthMgr.GetUserInfo().CurrentProjectId));
            parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
            parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));

            parameters.Add(new SqlParameter("@SortColumn", o_option));
            parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));


            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListDrawingViewer", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            if (result.AffectedRow < 1)
                result.ScalarValue = 0;
            else
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search

            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType DrawingBinding(TypeDrawing objDrawingId)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] bindingParm = new SqlParameter[] {
                                new SqlParameter("@ProjectId", userinfo.CurrentProjectId),
                                new SqlParameter("@UpdatedBy", userinfo.SigmaUserId),
                                new SqlParameter("@ResultMsg", SqlDbType.VarChar, 100), // sp에서 output 설정했을 경우
                                new SqlParameter("RETURN_VALUE",SqlDbType.Int) // sp에서 return 값을 설정했을경우 사용
                    };

            bindingParm[2].Direction = ParameterDirection.Output;
            bindingParm[3].Direction = ParameterDirection.ReturnValue;

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_UpdateBindingDrawing", bindingParm);

                string resultMsg = (string)bindingParm[2].Value;
                //Update 결과 건수
                int AffectedRow = (int)bindingParm[3].Value;
                
                result.IsSuccessful = true;
                result.ScalarValue = AffectedRow;
                result.StringValue = resultMsg;

                scope.Complete();
            }

            return result;
        }

        public SigmaResultType AddDrawing(TypeDrawing objDrawingId)
        {
            TransactionScope scope = null;
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            SigmaResultType result = new SigmaResultType();
            SigmaResultType refresult = new SigmaResultType();

            // * Ref Drawing Check
            if (!string.IsNullOrEmpty(objDrawingId.ReferenceDrawings))
            {
                string xlsRefDrawingno = objDrawingId.ReferenceDrawings;
                string[] arrRefDrawingno = xlsRefDrawingno.Split(',');

                foreach (string refdrawno in arrRefDrawingno)
                {
                    refresult = GetDrawingByNumber(refdrawno.Trim());

                    if (refresult.AffectedRow < 1)
                    {
                        result.IsSuccessful = false;
                        result.ErrorMessage = "Incorrect Reference Drawing";
                        return result;
                    }
                }
            }

            // * Detail Drawing Check
            if (!string.IsNullOrEmpty(objDrawingId.DetailedDrawings))
            {
                string xlsDetailDrawingno = objDrawingId.DetailedDrawings;
                string[] arrDetailDrawingno = xlsDetailDrawingno.Split(',');

                foreach (string detaildrawno in arrDetailDrawingno)
                {
                    refresult = GetDrawingByNumber(detaildrawno.Trim());

                    if (refresult.AffectedRow < 1)
                    {
                        result.IsSuccessful = false;
                        result.ErrorMessage = "Incorrect Detail Drawing";
                        return result;
                    }
                }
            }

            // * Image Add
            if (!string.IsNullOrEmpty(objDrawingId.FilePath) && string.IsNullOrEmpty(objDrawingId.FileStoreId))
            {   
                SigmaResultType imageresult = new SigmaResultType();
                ImportDrawingMgr importDrawingImage = new ImportDrawingMgr();
            
                //string rootPath = System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentUpload"];
                //string targetPath = System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentFolderRoot"];

                string rootPath = ConfigMgr.GetImportFilePath();
                string targetPath = ConfigMgr.GetTargetPath();
                            
                string filePath = rootPath + objDrawingId.FilePath;

                
                imageresult = importDrawingImage.AddDrawingImage(filePath, targetPath);

                if (!imageresult.IsSuccessful)
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = imageresult.ErrorMessage;
                    return result;
                }
            }
            //--------------------------------------------------------------------------------------------------------

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();
            string CreateBy = userinfo.SigmaUserId;

            

            SqlParameter[] drawingParm = new SqlParameter[] {
                                new SqlParameter("@ImportedSourceFileInfoID", 0), 
                                new SqlParameter("@CwpName", objDrawingId.CWP),
                                new SqlParameter("@Name", objDrawingId.Name), 
                                new SqlParameter("@FileName", objDrawingId.FileName), 
                                new SqlParameter("@Title", objDrawingId.Title),
                                new SqlParameter("@Description", objDrawingId.Description),
                                new SqlParameter("@Revision", objDrawingId.Revision),
                                new SqlParameter("@DrawingType", objDrawingId.DrawingType),
                                new SqlParameter("@CreatedBy", CreateBy),
                                new SqlParameter("@ProjectId", AuthMgr.GetUserInfo().CurrentProjectId),
                                new SqlParameter("@ResultMsg", SqlDbType.VarChar, 100),
                                new SqlParameter("@DrawingId",SqlDbType.Int) 
                    };

            drawingParm[10].Direction = ParameterDirection.Output;
            drawingParm[11].Direction = ParameterDirection.Output;

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddDrawing", drawingParm);

                string resultMsg = (string)drawingParm[10].Value;
                //DrawingID 번호 Return 받음
                int AffectedRow = (int)drawingParm[11].Value;

                if (AffectedRow > 0)
                {   
                    //result.IsSuccessful = true;
                    //result.ScalarValue = AffectedRow;


                    // Ref. Drawing 있다면 등록
                    if (!string.IsNullOrEmpty(objDrawingId.ReferenceDrawings))
                    {
                        string xlsRefDrawingno = objDrawingId.ReferenceDrawings;
                        string[] arrRefDrawingno = xlsRefDrawingno.Split(',');

                        foreach (string refdrawno in arrRefDrawingno)
                        {
                            SqlParameter[] refdrawingParm = new SqlParameter[] {
                                new SqlParameter("@RefDrawingNo", refdrawno.Trim()), 
                                new SqlParameter("@DrawingNo", objDrawingId.Name), 
                                new SqlParameter("@DetailDrawingNo", ""), 
                                new SqlParameter("@Revision", ""),
                                new SqlParameter("@CreatedBy", CreateBy),
                                new SqlParameter("RETURN_VALUE",SqlDbType.Int) // sp에서 return 값을 설정했을경우 사용
                            };

                            refdrawingParm[5].Direction = ParameterDirection.ReturnValue;

                            //using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                            //{
                            result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddReferenceDrawing", refdrawingParm);
                            //int AffectedRow = (int)drawingParm[5].Value;
                            AffectedRow = (int)refdrawingParm[5].Value;

                            //    scope.Complete();
                            //}
                        }
                    }

                    // Detail Drawing 있다면 등록
                    if (!string.IsNullOrEmpty(objDrawingId.DetailedDrawings))
                    {
                        string xlsDetailDrawingno = objDrawingId.DetailedDrawings;
                        string[] arrDetailDrawingno = xlsDetailDrawingno.Split(',');

                        foreach (string detaildrawno in arrDetailDrawingno)
                        {
                            SqlParameter[] detaildrawingParm = new SqlParameter[] {
                                new SqlParameter("@DetailDrawingNo", detaildrawno.Trim()), 
                                new SqlParameter("@DrawingNo", objDrawingId.Name), 
                                new SqlParameter("@Revision", ""),
                                new SqlParameter("@CreatedBy", CreateBy),
                                new SqlParameter("RETURN_VALUE",SqlDbType.Int) // sp에서 return 값을 설정했을경우 사용
                            };

                            detaildrawingParm[4].Direction = ParameterDirection.ReturnValue;

                            //using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                            //{
                            result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddDetailDrawing", detaildrawingParm);
                            AffectedRow = (int)detaildrawingParm[4].Value;

                            //    scope.Complete();
                            //}
                        }
                    }

                                                                           
                    // Add New 하고 Image 를 Upload 했다면 바로 Binding 처리 되도록 한다.
                    if (!string.IsNullOrEmpty(objDrawingId.FilePath) || !(string.IsNullOrEmpty(objDrawingId.FileStoreId)))
                    {
                        SqlParameter[] drawingBindingParm = new SqlParameter[] {
                                new SqlParameter("@DrawingId", AffectedRow),
                                new SqlParameter("@UpdatedBy", CreateBy),
                                new SqlParameter("@ResultMsg", SqlDbType.VarChar, 100), // sp에서 output 설정했을 경우
                                new SqlParameter("RETURN_VALUE",SqlDbType.Int) // sp에서 return 값을 설정했을경우 사용
                        };

                        drawingBindingParm[2].Direction = ParameterDirection.Output;
                        drawingBindingParm[3].Direction = ParameterDirection.ReturnValue;

                        //DrawingID 번호 Return 받음
                        result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_UpdateBindingDrawingById", drawingBindingParm);

                        //result.IsSuccessful = true;
                        //result.ScalarValue = AffectedRow;
                    }
                    result.IsSuccessful = true;
                    result.ScalarValue = AffectedRow;

                    scope.Complete();
                }
                else
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = resultMsg;
                }
                //scope.Complete();
            }

            return result;
        }

        public SigmaResultType UpdateDrawing(TypeDrawing objDrawingId)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();
            SigmaResultType refresult = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();
            string UpdatedBy = "leebw";

            // * Ref Drawing Check
            if (!string.IsNullOrEmpty(objDrawingId.ReferenceDrawings))
            {
                string xlsRefDrawingno = objDrawingId.ReferenceDrawings;
                string[] arrRefDrawingno = xlsRefDrawingno.Split(',');

                foreach (string refdrawno in arrRefDrawingno)
                {
                    refresult = GetDrawingByNumber(refdrawno.Trim());

                    if (refresult.AffectedRow < 1)
                    {
                        result.IsSuccessful = false;
                        result.ErrorMessage = "Incorrect Reference Drawing";
                        return result;
                    }
                }
            }

            // * Detail Drawing Check
            if (!string.IsNullOrEmpty(objDrawingId.DetailedDrawings))
            {
                string xlsDetailDrawingno = objDrawingId.DetailedDrawings;
                string[] arrDetailDrawingno = xlsDetailDrawingno.Split(',');

                foreach (string detaildrawno in arrDetailDrawingno)
                {
                    refresult = GetDrawingByNumber(detaildrawno.Trim());

                    if (refresult.AffectedRow < 1)
                    {
                        result.IsSuccessful = false;
                        result.ErrorMessage = "Incorrect Detail Drawing";
                        return result;
                    }
                }
            }

            // * Path 넘어오면 이미지 추가 - Image Add
            if (!string.IsNullOrEmpty(objDrawingId.FilePath))
            {
                SigmaResultType imageresult = new SigmaResultType();
                ImportDrawingMgr importDrawingImage = new ImportDrawingMgr();

                //string rootPath = System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentUpload"];
                //string targetPath = System.Web.Configuration.WebConfigurationManager.AppSettings["DocumentFolderRoot"];

                string rootPath = ConfigMgr.GetImportFilePath();
                string targetPath = ConfigMgr.GetTargetPath();

                string filePath = rootPath + objDrawingId.FilePath;


                imageresult = importDrawingImage.AddDrawingImage(filePath, targetPath);
            }
            //--------------------------------------------------------------------------------------------------------
            

            SqlParameter[] drawingParm = new SqlParameter[] {
                                new SqlParameter("@DrawingId", objDrawingId.DrawingId),
                                new SqlParameter("@CwpName", objDrawingId.CWP),
                                new SqlParameter("@Name", objDrawingId.Name), 
                                new SqlParameter("@FileName", objDrawingId.FileName), 
                                new SqlParameter("@Title", objDrawingId.Title),
                                new SqlParameter("@Description", objDrawingId.Description),
                                new SqlParameter("@Revision", objDrawingId.Revision),
                                new SqlParameter("@DrawingType", objDrawingId.DrawingType),
                                new SqlParameter("@UpdatedBy", UpdatedBy),
                                new SqlParameter("@ResultMsg", SqlDbType.VarChar, 100), // sp에서 output 설정했을 경우
                                new SqlParameter("RETURN_VALUE",SqlDbType.Int) // sp에서 return 값을 설정했을경우 사용
                    };

            drawingParm[9].Direction = ParameterDirection.Output;
            drawingParm[10].Direction = ParameterDirection.ReturnValue;

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_UpdateDrawing", drawingParm);

                string resultMsg = (string)drawingParm[9].Value;
                int AffectedRow = (int)drawingParm[10].Value;

                if (AffectedRow > 0)
                {

                    // Ref. Drawing 있다면 등록
                    if (!string.IsNullOrEmpty(objDrawingId.ReferenceDrawings))
                    {
                        string xlsRefDrawingno = objDrawingId.ReferenceDrawings;
                        string[] arrRefDrawingno = xlsRefDrawingno.Split(',');

                        foreach (string refdrawno in arrRefDrawingno)
                        {
                            SqlParameter[] refdrawingParm = new SqlParameter[] {
                                new SqlParameter("@RefDrawingNo", refdrawno.Trim()), 
                                new SqlParameter("@DrawingNo", objDrawingId.Name), 
                                new SqlParameter("@DetailDrawingNo", ""), 
                                new SqlParameter("@Revision", ""),
                                new SqlParameter("@CreatedBy", UpdatedBy),
                                new SqlParameter("RETURN_VALUE",SqlDbType.Int) // sp에서 return 값을 설정했을경우 사용
                            };

                            refdrawingParm[5].Direction = ParameterDirection.ReturnValue;

                            //using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                            //{
                            result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddReferenceDrawing", refdrawingParm);
                                //int AffectedRow = (int)drawingParm[5].Value;
                            AffectedRow = (int)refdrawingParm[5].Value;

                            //    scope.Complete();
                            //}
                        }
                    }

                    // Detail Drawing 있다면 등록
                    if (!string.IsNullOrEmpty(objDrawingId.DetailedDrawings))
                    {
                        string xlsDetailDrawingno = objDrawingId.DetailedDrawings;
                        string[] arrDetailDrawingno = xlsDetailDrawingno.Split(',');

                        foreach (string detaildrawno in arrDetailDrawingno)
                        {
                            SqlParameter[] detaildrawingParm = new SqlParameter[] {
                                new SqlParameter("@DetailDrawingNo", detaildrawno.Trim()), 
                                new SqlParameter("@DrawingNo", objDrawingId.Name), 
                                new SqlParameter("@Revision", ""),
                                new SqlParameter("@CreatedBy", UpdatedBy),
                                new SqlParameter("RETURN_VALUE",SqlDbType.Int) // sp에서 return 값을 설정했을경우 사용
                            };

                            detaildrawingParm[4].Direction = ParameterDirection.ReturnValue;

                            //using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                            //{
                            result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddDetailDrawing", detaildrawingParm);
                            AffectedRow = (int)detaildrawingParm[4].Value;

                            //    scope.Complete();
                            //}
                        }
                    }

                    // Image 를 Upload 했다면 바로 Binding 처리 되도록 한다.
                    if (!string.IsNullOrEmpty(objDrawingId.FilePath))
                    {
                        SqlParameter[] drawingBindingParm = new SqlParameter[] {
                                new SqlParameter("@DrawingId", objDrawingId.DrawingId),
                                new SqlParameter("@UpdatedBy", objDrawingId.UpdatedBy),
                                new SqlParameter("@ResultMsg", SqlDbType.VarChar, 100), // sp에서 output 설정했을 경우
                                new SqlParameter("RETURN_VALUE",SqlDbType.Int) // sp에서 return 값을 설정했을경우 사용
                        };

                        drawingBindingParm[2].Direction = ParameterDirection.Output;
                        drawingBindingParm[3].Direction = ParameterDirection.ReturnValue;

                        //DrawingID 번호 Return 받음
                        result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_UpdateBindingDrawingById", drawingBindingParm);

                        //result.IsSuccessful = true;
                        //result.ScalarValue = AffectedRow;
                    }

                    result.IsSuccessful = true;
                    result.ScalarValue = AffectedRow;
                }
                else
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = resultMsg;
                }
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType RemoveDrawing(TypeDrawing objDrawingId)
        {
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@DrawingId", objDrawingId.DrawingId) };
            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveDrawing", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType MultiDrawing(List<TypeDrawing> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypeDrawing anObj in listObj)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            result = AddDrawing(anObj);
                            break;
                        case "U":
                            result = UpdateDrawing(anObj);
                            break;
                        case "D":
                            result = RemoveDrawing(anObj);
                            break;
                    }
                }

                scope.Complete();
                //result.IsSuccessful = true;
            }
            return result;
        }

    }
}
