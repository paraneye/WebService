using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using System.Data;

using Element.Shared.Common;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.Types.Auth;
using Element.Sigma.Web.Biz.Auth;
using System.IO;
using Element.Sigma.Web.Biz.Common;
using System.Security.Cryptography;
using System.Text;

namespace Element.Sigma.Web.Biz.GlobalSettings
{
    public class SigmaUserMgr
    {
        #region SigmaUser

        public SigmaResultType GetSigmaUser(string sigmaUserId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@sigmaUserId", sigmaUserId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetSigmaUser", parameters);
            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListSigmaUser(string offset, string max, List<string> s_option, List<string> s_key, string o_option, string o_desc)
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
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListSigmaUser", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0]; // returning count
            result.ScalarValue = (int)ds.Tables[2].Rows[0][0]; // total count by search
            result.IsSuccessful = true;
            // return
            return result;
        }

        private string RandumPassword()
        {
            int passLength = 10;
            string password = "";
            Random r = new Random();
            for (int i = 0; i < passLength; i++)
            {
                //int aa = r.Next(1, 3);
                switch (r.Next(1, 4) % 3)
                {
                    case 0:
                        password += (char)r.Next(48, 58);
                        break;
                    case 1:
                        password += (char)r.Next(65, 91);
                        break;
                    case 2:
                        password += (char)r.Next(97, 123);
                        break;
                }
            }


            return password;
        }

        private string GetMD5Hash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString().ToLower();
        }

        public SigmaResultType AddSigmaUser(TypeSigmaUser objSigmaUser)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            objSigmaUser.CreatedBy = userinfo.SigmaUserId;

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();
            string pwd = RandumPassword();
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@SigmaUserId", objSigmaUser.SigmaUserId));
            paramList.Add(new SqlParameter("@CompanyId", objSigmaUser.CompanyId));
            paramList.Add(new SqlParameter("@EmployeeId", objSigmaUser.EmployeeId));
            paramList.Add(new SqlParameter("@FirstName", objSigmaUser.FirstName));
            paramList.Add(new SqlParameter("@LastName", objSigmaUser.LastName));
            paramList.Add(new SqlParameter("@PhoneNo", objSigmaUser.PhoneNo));
            paramList.Add(new SqlParameter("@Email", objSigmaUser.Email));
            paramList.Add(new SqlParameter("@PhotoUrl", objSigmaUser.PhotoUrl));
            paramList.Add(new SqlParameter("@Password", GetMD5Hash(RandumPassword())));
            paramList.Add(new SqlParameter("@CreatedBy", objSigmaUser.CreatedBy));


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddSigmaUser", paramList.ToArray());
                
                objSigmaUser.Password = pwd;

                MailMgr mailMgr = new MailMgr();

                mailMgr.SendMail(objSigmaUser);

                result.IsSuccessful = true;

                scope.Complete();
            }

            return result;
        }

        public SigmaResultType InitPassword(TypeSigmaUser objSigmaUser)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();
            string pwd = RandumPassword();
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@SigmaUserId", objSigmaUser.SigmaUserId));
            paramList.Add(new SqlParameter("@Password", GetMD5Hash(pwd)));
            paramList.Add(new SqlParameter("@Updatedby", objSigmaUser.SigmaUserId));
            paramList.Add(new SqlParameter("@IsActivated", "N"));


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_UpdateSigmaUserForPassword", paramList.ToArray());
                result.IsSuccessful = true;
                result.StringValue = pwd;
                scope.Complete();
            }

            return result;
        }


        public SigmaResultType AddSigmaUserTemplate(TypeSigmaUser objSigmaUser)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            objSigmaUser.CreatedBy = userinfo.SigmaUserId;

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();
            string pwd = RandumPassword();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@SigmaUserId", objSigmaUser.SigmaUserId));
            paramList.Add(new SqlParameter("@CompanyName", objSigmaUser.CompanyName));
            paramList.Add(new SqlParameter("@EmployeeId", objSigmaUser.EmployeeId));
            paramList.Add(new SqlParameter("@FirstName", objSigmaUser.FirstName));
            paramList.Add(new SqlParameter("@LastName", objSigmaUser.LastName));
            paramList.Add(new SqlParameter("@PhoneNo", objSigmaUser.PhoneNo));
            paramList.Add(new SqlParameter("@Email", objSigmaUser.Email));
            paramList.Add(new SqlParameter("@PhotoUrl", objSigmaUser.PhotoUrl));
            paramList.Add(new SqlParameter("@Password", GetMD5Hash(RandumPassword())));
            paramList.Add(new SqlParameter("@CreatedBy", objSigmaUser.CreatedBy));
            SqlParameter outParam = new SqlParameter("@ExMessage", SqlDbType.NVarChar, 100);
            outParam.Direction = ParameterDirection.Output;
            paramList.Add(outParam);

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddSigmaUserByTemplate", paramList.ToArray());
                result.IsSuccessful = true;
                if (!string.IsNullOrEmpty(outParam.Value.ToString()))
                    result.ErrorMessage = outParam.Value.ToString();
                else
                {
                    objSigmaUser.Password = pwd;

                    MailMgr mailMgr = new MailMgr();

                    mailMgr.SendMail(objSigmaUser);
                }

                scope.Complete();
            }

            return result;
        }

        public SigmaResultType UpdateSigmaUser(TypeSigmaUser objSigmaUser)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            objSigmaUser.UpdatedBy = userinfo.SigmaUserId;
 
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SigmaUserId", objSigmaUser.SigmaUserId),
					new SqlParameter("@CompanyId", objSigmaUser.CompanyId),
					new SqlParameter("@EmployeeId", objSigmaUser.EmployeeId),
					new SqlParameter("@FirstName", objSigmaUser.FirstName),
					new SqlParameter("@LastName", objSigmaUser.LastName),
					new SqlParameter("@PhoneNo", objSigmaUser.PhoneNo),
					new SqlParameter("@Email", objSigmaUser.Email),
					new SqlParameter("@PhotoUrl", objSigmaUser.PhotoUrl),
					new SqlParameter("@Password", objSigmaUser.Password),
					new SqlParameter("@IsActive", objSigmaUser.IsActive),
					new SqlParameter("@UpdatedBy", objSigmaUser.UpdatedBy)
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateSigmaUser", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }

        private string GetSigmaUserPassword(string sigmaUserId)
        {
            string rslt = string.Empty;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@sigmaUserId", sigmaUserId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetSigmaUserPassword", parameters);

            if (ds.Tables[0].Rows.Count > 0)
                rslt = ds.Tables[0].Rows[0]["Password"].ToString();
            return rslt;
        }

        public SigmaResultType UpdateUserProfile(TypeSigmaUser objSigmaUser)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            objSigmaUser.UpdatedBy = userinfo.SigmaUserId;

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            if (!string.IsNullOrEmpty(objSigmaUser.OldPassword) && !objSigmaUser.OldPassword.Equals(GetSigmaUserPassword(objSigmaUser.SigmaUserId)))
            {
                result.JsonDataSet = "[]";
                result.AffectedRow = 0;
                result.IsSuccessful = false;
                result.ErrorCode = "AUTH0003";
                result.ErrorMessage = MessageHandler.GetErrorMessage("AUTH0003");
                return result;
            }

            if (!string.IsNullOrEmpty(objSigmaUser.NewPassword) && !string.IsNullOrEmpty(objSigmaUser.ConfirmNewPassword) && !objSigmaUser.NewPassword.Equals(objSigmaUser.ConfirmNewPassword))
            {
                // Compose parameters
                SqlParameter[] passwordParameters = new SqlParameter[] {
                    new SqlParameter("@userId", objSigmaUser.EmployeeId), 
                    new SqlParameter("@passwd", objSigmaUser.OldPassword)
                };

                // Get Data 

                DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetLogin", passwordParameters);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    result.JsonDataSet = "[]";
                    result.AffectedRow = 0;
                    result.IsSuccessful = false;
                    result.ErrorCode = "AUTH0004";
                    result.ErrorMessage = MessageHandler.GetErrorMessage("AUTH0004");
                    return result;
                }
            }
            else if (!string.IsNullOrEmpty(objSigmaUser.NewPassword) && !string.IsNullOrEmpty(objSigmaUser.ConfirmNewPassword) && objSigmaUser.NewPassword.Equals(objSigmaUser.ConfirmNewPassword))
            {
                objSigmaUser.Password = objSigmaUser.NewPassword;
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SigmaUserId", objSigmaUser.SigmaUserId),
					new SqlParameter("@CompanyId", AuthMgr.GetUserInfo().CompanyId),
					new SqlParameter("@EmployeeId", objSigmaUser.EmployeeId),
					new SqlParameter("@FirstName", objSigmaUser.FirstName),
					new SqlParameter("@LastName", objSigmaUser.LastName),
					new SqlParameter("@PhoneNo", objSigmaUser.PhoneNo),
					new SqlParameter("@Email", objSigmaUser.Email),
					new SqlParameter("@PhotoUrl", objSigmaUser.PhotoUrl),
					new SqlParameter("@Password", objSigmaUser.Password),
					new SqlParameter("@IsActive", objSigmaUser.IsActive),
                    new SqlParameter("@DefaultProjectId", objSigmaUser.DefaultProjectId),
					new SqlParameter("@UpdatedBy", objSigmaUser.UpdatedBy)
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateUserProfile", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType UpdatePassword(TypeSigmaUser objSigmaUser)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            if (!string.IsNullOrEmpty(objSigmaUser.OldPassword) && !objSigmaUser.OldPassword.Equals(GetSigmaUserPassword(objSigmaUser.SigmaUserId)))
            {
                result.JsonDataSet = "[]";
                result.AffectedRow = 0;
                result.IsSuccessful = false;
                result.ErrorCode = "AUTH0003";
                result.ErrorMessage = MessageHandler.GetErrorMessage("AUTH0003");
                return result;
            }

            if (!string.IsNullOrEmpty(objSigmaUser.NewPassword) && !string.IsNullOrEmpty(objSigmaUser.ConfirmNewPassword) && !objSigmaUser.NewPassword.Equals(objSigmaUser.ConfirmNewPassword))
            {
                // Compose parameters
                SqlParameter[] passwordParameters = new SqlParameter[] {
                    new SqlParameter("@userId", objSigmaUser.EmployeeId), 
                    new SqlParameter("@passwd", objSigmaUser.OldPassword)
                };

                // Get Data 

                DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetLogin", passwordParameters);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    result.JsonDataSet = "[]";
                    result.AffectedRow = 0;
                    result.IsSuccessful = false;
                    result.ErrorCode = "AUTH0004";
                    result.ErrorMessage = MessageHandler.GetErrorMessage("AUTH0004");
                    return result;
                }
            }
            else if (!string.IsNullOrEmpty(objSigmaUser.NewPassword) && !string.IsNullOrEmpty(objSigmaUser.ConfirmNewPassword) && objSigmaUser.NewPassword.Equals(objSigmaUser.ConfirmNewPassword))
            {
                objSigmaUser.Password = objSigmaUser.NewPassword;
            }

            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SigmaUserId", objSigmaUser.SigmaUserId),
					new SqlParameter("@Password", objSigmaUser.Password),
					new SqlParameter("@UpdatedBy", objSigmaUser.SigmaUserId),
                    new SqlParameter("@IsActivated", "Y")
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateSigmaUserForPassword", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType RemoveSigmaUser(TypeSigmaUser objSigmaUser)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SigmaUserId", objSigmaUser.SigmaUserId),
                    new SqlParameter("@UpdatedBy", userinfo.SigmaUserId)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveSigmaUser", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType MultiUsers(TypeSigmaUser objSigmaUser)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            if(objSigmaUser.SigmaOperation == "D"){
                result = RemoveSigmaUser(objSigmaUser);
            }else
            {
                switch (objSigmaUser.SigmaOperation)
                {
                    case "C":
                        if (IsAddUser())
                            result = AddSigmaUser(objSigmaUser);
                        else
                        {
                            result.IsSuccessful = false;
                            result.ErrorMessage = "You have exceeded the number of user licenses.";
                        }
                        break;
                    case "U":
                        result = UpdateSigmaUser(objSigmaUser);
                        break;
                }

                if (result.IsSuccessful)
                {
                    TypeSigmaUserSigmaRole objSigmaUserSigmaRole = new TypeSigmaUserSigmaRole();
                    objSigmaUserSigmaRole.SigmaUserId = objSigmaUser.SigmaUserId;
                    result = MultiSigmaUserSigmaRole(objSigmaUserSigmaRole, objSigmaUser.SigmaUserSigmaRoles);
                }
            }

            

            return result;
        }

        public SigmaResultType MultiSigmaUser(List<TypeSigmaUser> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {

                foreach (TypeSigmaUser anObj in listObj)
                {
                    switch (anObj.SigmaOperation)
                    {
                        case "C":
                            AddSigmaUser(anObj);
                            break;
                        case "U":
                            UpdateSigmaUser(anObj);
                            break;
                        case "D":
                            anObj.IsActive = "N";
                            UpdateSigmaUser(anObj);
                            break;
                    }
                }

                scope.Complete();
            }

            return result;
        }

        private int GetAvailableLicenseCount()
        {
            int result = 0;
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            string connStr = ConnStrHelper.getDbConnString();
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@CompanyId", userinfo.CompanyId)
            };
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetLicense", parameters);

            if (ds.Tables[0].Rows.Count > 0)
                result = Convert.ToInt32(ds.Tables[0].Rows[0]["AvailableCount"]);

            return result;
        }

        private bool IsAddUser()
        {
            bool result = false;

            if (GetAvailableLicenseCount() > 0)
                result = true;

            return result;
        }

        public SigmaResultType ImportSigmaUserFromExcel(string filePath, string exportfilepath)
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
            int SuccessCnt = 1;

            int availableCnt = GetAvailableLicenseCount();

            

            foreach (DataRow r in dt.Rows)
            {
                if (SuccessCnt > availableCnt)
                {
                    tmpdt.Rows.Add(r.ItemArray);
                    tmpdt.Rows[tmpdt.Rows.Count - 1]["Fail reason"] = "Exceeded the number of user licenses";
                    failCnt++;
                }
                else
                {
                    TypeSigmaUser obj = new TypeSigmaUser();
                    obj.SigmaUserId = r[0].ToString();
                    obj.EmployeeId = r[1].ToString();
                    obj.FirstName = r[2].ToString();
                    obj.LastName = r[3].ToString();
                    obj.PhoneNo = r[4].ToString();
                    obj.Email = r[5].ToString();
                    obj.Password = RandumPassword();
                    obj.CompanyName = r[6].ToString();
                    obj.CreatedBy = userinfo.SigmaUserId;

                    if (string.IsNullOrEmpty(GetFailreasonForRequiredUser(r)))
                    {
                        SigmaResultType rst = AddSigmaUserTemplate(obj);

                        if (rst.ErrorMessage != null)
                        {
                            tmpdt.Rows.Add(r.ItemArray);
                            tmpdt.Rows[tmpdt.Rows.Count - 1]["Fail reason"] = rst.ErrorMessage.ToString();
                            failCnt++;
                        }
                        else
                            SuccessCnt++;
                    }
                    else
                    {
                        tmpdt.Rows.Add(r.ItemArray);
                        tmpdt.Rows[tmpdt.Rows.Count - 1]["Fail reason"] = GetFailreasonForRequiredUser(r);
                        failCnt++;
                    }
                }
            }
            TypeImportHistory ImportHistory = new TypeImportHistory();
            ImportHistory.ImportCategory = "User";
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

        private string GetFailreasonForRequiredUser(DataRow r)
        {
            string rslt = string.Empty;
            if (string.IsNullOrEmpty(r[0].ToString()))
                rslt += "Login ID,";
            if (string.IsNullOrEmpty(r[1].ToString()))
                rslt += "Employee ID,";
            if (string.IsNullOrEmpty(r[2].ToString()))
                rslt += "First Name,";
            if (string.IsNullOrEmpty(r[3].ToString()))
                rslt += "Last Name,";
            if (string.IsNullOrEmpty(r[5].ToString()))
                rslt += "Email,";
            
            rslt = rslt.Length > 0 ? rslt.Substring(0, rslt.Length - 1) + " is required." : string.Empty;
            return rslt;
        }

        #endregion

        #region SigmaUserSigmaRole

        public SigmaResultType GetSigmaUserSigmaRole(string sigmaUserId)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@sigmaUserId", sigmaUserId)
                };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetSigmaUserSigmaRole", parameters);

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = 1;
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType ListSigmaUserSigmaRole(string offset, string max, string s_option, string s_key, string o_option, string o_desc)
        {
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter(string.Format("@{0}", s_option), s_key));

            parameters.Add(new SqlParameter("@MaxNumRows", (max == null ? 1000 : int.Parse(max))));
            parameters.Add(new SqlParameter("@RetrieveOffset", (offset == null ? 0 : int.Parse(offset))));

            parameters.Add(new SqlParameter("@SortColumn", o_option));
            parameters.Add(new SqlParameter("@SortOrder", (o_desc != null ? o_desc.ToUpper() : null)));


            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_ListSigmaUserSigmaRole", parameters.ToArray());

            // Convert to REST/JSON String
            result.JsonDataSet = JsonHelper.convertDataTableToJson(ds.Tables[0]);
            result.AffectedRow = (int)ds.Tables[1].Rows[0][0];
            result.IsSuccessful = true;
            // return
            return result;
        }

        public SigmaResultType AddSigmaUserSigmaRole(TypeSigmaUserSigmaRole objSigmaUserSigmaRole)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            objSigmaUserSigmaRole.CreatedBy = userinfo.SigmaUserId;
            //objSigmaUserSigmaRole.ProjectId = userinfo.CurrentProjectId;

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@SigmaRoleId", objSigmaUserSigmaRole.SigmaRoleId));
            paramList.Add(new SqlParameter("@SigmaUserId", objSigmaUserSigmaRole.SigmaUserId));
            paramList.Add(new SqlParameter("@ReportTo", objSigmaUserSigmaRole.ReportTo));
            paramList.Add(new SqlParameter("@ReportToRole", objSigmaUserSigmaRole.ReportToRole));
            paramList.Add(new SqlParameter("@IsDefault", objSigmaUserSigmaRole.IsDefault));
            paramList.Add(new SqlParameter("@ProjectId", objSigmaUserSigmaRole.ProjectId));
            paramList.Add(new SqlParameter("@CreatedBy", objSigmaUserSigmaRole.CreatedBy));

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddSigmaUserSigmaRole", paramList.ToArray());
                result.IsSuccessful = true;
            
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType UpdateSigmaUserSigmaRole(TypeSigmaUserSigmaRole objSigmaUserSigmaRole)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            objSigmaUserSigmaRole.CreatedBy = userinfo.SigmaUserId;
            objSigmaUserSigmaRole.UpdatedBy = userinfo.SigmaUserId;
            objSigmaUserSigmaRole.ProjectId = userinfo.CurrentProjectId;

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
					new SqlParameter("@ReportTo", objSigmaUserSigmaRole.ReportTo),
					new SqlParameter("@ReportToRole", objSigmaUserSigmaRole.ReportToRole),
					new SqlParameter("@IsDefault", objSigmaUserSigmaRole.IsDefault),
					new SqlParameter("@ProjectId", objSigmaUserSigmaRole.ProjectId),
					new SqlParameter("@CreatedBy", objSigmaUserSigmaRole.CreatedBy),
					new SqlParameter("@UpdatedBy", objSigmaUserSigmaRole.UpdatedBy),
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateSigmaUserSigmaRole", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }
        
        public SigmaResultType RemoveSigmaUserSigmaRole(TypeSigmaUserSigmaRole objSigmaUserSigmaRole)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SigmaUserId", objSigmaUserSigmaRole.SigmaUserId)
                };


            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveSigmaUserSigmaRole", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType UpdateSigmaUserSigmaRoleForHierarchy(TypeSigmaUserSigmaRole objSigmaUserSigmaRole)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                    new SqlParameter("@SigmaTrgRoleId", objSigmaUserSigmaRole.SigmaTrgRoleId),
                    new SqlParameter("@SigmaRoleId", objSigmaUserSigmaRole.SigmaRoleId),
				    new SqlParameter("@SigmaUserId", objSigmaUserSigmaRole.SigmaUserId),
                    new SqlParameter("@ProjectId", userinfo.CurrentProjectId),
					new SqlParameter("@UpdatedBy", userinfo.SigmaUserId),
                };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_UpdateSigmaUserSigmaRoleForHierarchy", parameters);
                result.IsSuccessful = true;
                scope.Complete();

            }

            return result;
        }

        public SigmaResultType RemoveSigmaUserSigmaRoleForHierarchy(TypeSigmaUserSigmaRole objSigmaUserSigmaRole)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@SigmaUserId", objSigmaUserSigmaRole.SigmaUserId),
                new SqlParameter("@SigmaRoleId", objSigmaUserSigmaRole.SigmaRoleId),
                new SqlParameter("@ProjectId", userinfo.CurrentProjectId),
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveSigmaUserSigmaRoleForHierarchy", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType RemoveSigmaUserSigmaRoleByProjectId(TypeSigmaUserSigmaRole objSigmaUserSigmaRole)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            objSigmaUserSigmaRole.ProjectId = userinfo.CurrentProjectId;

            SigmaResultType result = new SigmaResultType();
            TransactionScope scope = null;

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@SigmaRoleId", objSigmaUserSigmaRole.SigmaRoleId),
                new SqlParameter("@ProjectId", objSigmaUserSigmaRole.ProjectId),
            };

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, "usp_RemoveSigmaUserSigmaRoleByProjectId", parameters);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public SigmaResultType MultiSigmaUserSigmaRole(TypeSigmaUserSigmaRole objSigmaUserSigmaRole, List<TypeSigmaUserSigmaRole> listObj)
        {
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                if(objSigmaUserSigmaRole != null)
                    RemoveSigmaUserSigmaRole(objSigmaUserSigmaRole);

                foreach (TypeSigmaUserSigmaRole anObj in listObj)
                {
                    AddSigmaUserSigmaRole(anObj);
                }
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }

        public DataSet GetSigmaUserSigmaRoleBySigmaRoleId(int projectId, int sigmaRoleId)
        {
            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            // Compose parameters
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@ProjectId", projectId),
                new SqlParameter("@SigmaRoleId", sigmaRoleId)
            };

            // Get Data 
            DataSet ds = SqlHelper.ExecuteDataset(connStr, "usp_GetSigmaUserSigmaRoleBySigmaRoleId", parameters);

            // return
            return ds;
        }

        public SigmaResultType AddSigmaUserSigmaRoleForProject(TypeSigmaUserSigmaRole objSigmaUserSigmaRole)
        {
            
            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@SigmaRoleId", objSigmaUserSigmaRole.SigmaRoleId));
            paramList.Add(new SqlParameter("@SigmaUserId", objSigmaUserSigmaRole.SigmaUserId));
            paramList.Add(new SqlParameter("@ReportTo", objSigmaUserSigmaRole.ReportTo));
            paramList.Add(new SqlParameter("@ReportToRole", objSigmaUserSigmaRole.ReportToRole));
            paramList.Add(new SqlParameter("@IsDefault", objSigmaUserSigmaRole.IsDefault));
            paramList.Add(new SqlParameter("@ProjectId", objSigmaUserSigmaRole.ProjectId));
            paramList.Add(new SqlParameter("@CreatedBy", AuthMgr.GetUserInfo().SigmaUserId));

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddSigmaUserSigmaRole", paramList.ToArray());
                result.IsSuccessful = true;

                scope.Complete();
            }

            return result;
        }

        #endregion
    }
}
