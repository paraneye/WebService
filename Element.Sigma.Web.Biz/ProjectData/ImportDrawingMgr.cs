using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Transactions;
using Element.Shared.Common;
using System.Web;
using Element.Sigma.Web.Biz.Common;
using Element.Sigma.Web.Biz.Types.GlobalSettings;
using Element.Sigma.Web.Biz.ProjectData;
using Element.Sigma.Web.Biz.Types.Auth;
using Element.Sigma.Web.Biz.Auth;
using Element.Sigma.Web.Biz.GlobalSettings;
using Element.Sigma.Web.Biz.Types.ProjectData;

namespace Element.Sigma.Web.Biz.ProjectData
{
    public class ImportDrawingMgr
    {
        #region Upload Drawing 

        public double maxdelaysecond = 3;
        bool isFinished = false;
        PDFLibNet.PDFWrapper pdfDoc;

        public SigmaResultType AddDrawingImage(string sourcePath, string targetPath)
        {
            SigmaResultType result = new SigmaResultType();
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();
            string importedfilename = Path.GetFileNameWithoutExtension(sourcePath);
            FileInfo fileinfo = new FileInfo(sourcePath);
            long fileSize = fileinfo.Length; // byte
            string fileExtention = Path.GetExtension(sourcePath);

            if (File.Exists(sourcePath))
            {
                if (isValidated(result, fileExtention, importedfilename))
                {
                    List<string> rnd = GetRandomPathInfo();

                    string targetChildPath = System.IO.Path.Combine(userinfo.CompanyName, userinfo.CurrentProjectId.ToString(), "Drawing", rnd[0]);

                    targetPath = System.IO.Path.Combine(targetPath, targetChildPath);

                    if (!System.IO.Directory.Exists(targetPath))
                    {
                        System.IO.Directory.CreateDirectory(targetPath);
                    }

                    File.Move(sourcePath, System.IO.Path.Combine(targetPath, rnd[1] + fileExtention));

                    ConvertPdfToJpg(System.IO.Path.Combine(targetPath, rnd[1] + fileExtention), System.IO.Path.Combine(targetPath, rnd[1]));

                    result = AddUploadedFileInfo(importedfilename, System.IO.Path.Combine(targetChildPath, rnd[1] + ".jpg"), fileSize, fileExtention);
                }
                else
                {
                    System.IO.File.Delete(sourcePath);
                }
            }
            else
            {
                result.IsSuccessful = false;
                result.ErrorMessage = "The File is not  exists";
            }

            return result;
        }

        private SigmaResultType AddUploadedFileInfo(string importedfilename, string targetFilePath, long fileSize, string fileExtention)
        {
            TransactionScope scope = null;

            SigmaResultType result = new SigmaResultType();
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            SqlParameter[] fileStoreParm = new SqlParameter[] {
                    new SqlParameter("@FileStoreID", SqlDbType.Int, 10), 
                    new SqlParameter("@Title", importedfilename), 
                    new SqlParameter("@Description", importedfilename),
                    new SqlParameter("@Category", "FILE_CATEGORY_DRAWING"),
                    new SqlParameter("@TypeCode", "FILE_TYPE_DRAWING"),
                    new SqlParameter("@CreatedBy", userinfo.SigmaUserId),
                    new SqlParameter("@ProjectId", userinfo.CurrentProjectId),
                    new SqlParameter("RETURN_VALUE",SqlDbType.Int)
                };

            fileStoreParm[0].Direction = ParameterDirection.Output;
            fileStoreParm[7].Direction = ParameterDirection.ReturnValue;

            string connStr = ConnStrHelper.getDbConnString();

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddFileStoreDrawing", fileStoreParm);

                int fileStroeId = (int)fileStoreParm[0].Value;
                int AffectedRow = (int)fileStoreParm[6].Value;

                // Compose parameters
                SqlParameter[] uploadfileParm = new SqlParameter[] {
                        new SqlParameter("@UploadedFileInfoId", SqlDbType.Int, 10), 
                        new SqlParameter("@FileStoreID", fileStroeId),
                        new SqlParameter("@Name", importedfilename), 
                        new SqlParameter("@Size", fileSize),
                        new SqlParameter("@Path", targetFilePath),
                        new SqlParameter("@FileExtension", fileExtention),
                        new SqlParameter("@Revision", "None"),
                        new SqlParameter("@FileType", "FILE_TYPE_DRAWING"),
                        new SqlParameter("@CreatedBy", userinfo.SigmaUserId),
                        new SqlParameter("RETURN_VALUE",SqlDbType.Int) 
                    };

                uploadfileParm[0].Direction = ParameterDirection.Output;
                uploadfileParm[9].Direction = ParameterDirection.ReturnValue;


                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddUploadedFileInfoDrawing", uploadfileParm);
                result.IsSuccessful = true;
                scope.Complete();
            }

            return result;
        }
        string mMovedPath = "", mConvertPath = "", mTargetPath = "";
        private void ConvertPdfToJpg(string movedPath, string targetPath)
        {
            string convertPath = string.Empty;
            try
            {
                DateTime st = DateTime.Now;
                if (File.Exists(movedPath))
                {
                    pdfDoc = new PDFLibNet.PDFWrapper();
                    pdfDoc.ExportJpgFinished += pdfDoc_ExportJpgFinished;
                    pdfDoc.LoadPDF(movedPath);
                    convertPath = targetPath + ".jpg";

                    mMovedPath = movedPath; mConvertPath = convertPath; mTargetPath = targetPath;
                    pdfDoc.ExportJpg(convertPath, 1, 1, 150, 90, 1);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                pdfDoc.Dispose();
                if (File.Exists(movedPath))
                    File.Delete(movedPath);
                throw new Exception("ConvertPdfToJpg Convert exception", ex);
            }
        }

        void pdfDoc_ExportJpgFinished()
        {
            isFinished = true;
            pdfDoc.Dispose();
            GenerateThumnail();
        }

        private void GenerateThumnail()
        {
            try
            {
                DateTime st = DateTime.Now;
                while (true)
                {
                    if (isBreakLoop(st))
                    {
                        throw new Exception();
                    }

                    if (File.Exists(mConvertPath))
                    {
                        System.IO.Stream imgstream = File.Open(mConvertPath, FileMode.Open);
                        System.Drawing.Image sourceImage = System.Drawing.Image.FromStream(imgstream);

                        float orgheight = sourceImage.PhysicalDimension.Height;
                        float orgwidth = sourceImage.PhysicalDimension.Width;
                        int newwidth = 200;

                        float newheight = orgheight / orgwidth * newwidth;

                        System.Drawing.Image thumbnailImage = sourceImage.GetThumbnailImage(newwidth, (int)newheight, null, IntPtr.Zero);
                        thumbnailImage.Save(mTargetPath + ".thumbnail" + ".jpg");

                        imgstream.Dispose();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                if (File.Exists(mMovedPath))
                    File.Delete(mMovedPath);
                if (File.Exists(mConvertPath))
                    File.Delete(mConvertPath);
                throw new Exception("GenerateThumnail exception", ex);
            }
        }

        private List<string> GetRandomPathInfo()
        {
            List<string> result = new List<string>();
            string tmp = Guid.NewGuid().ToString().Replace("-","");
            result.Add(tmp.Substring(0, 1));
            result.Add(tmp);

            return result;
        }

        private bool isValidated(SigmaResultType result, string fileExtention, string importedfilename)
        {
            bool rtn = false;
            if (fileExtention.ToUpper() == ".PDF")
            {
                if (isExistFile(importedfilename))
                {
                    rtn = true;
                }
                else
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = "The File already exists";
                }

            }
            else
            {
                result.IsSuccessful = false;
                result.ErrorMessage = "Invalid File Extention";
            }
            return rtn;
        }

        private bool isExistFile(string importedfilename)
        {
            UploadedFileInfoMgr uploadedfileinfoMgr = new UploadedFileInfoMgr();

            if (uploadedfileinfoMgr.GetUploadedFileInfoCountByName(importedfilename) > 0)
                return false;
            else
                return true;
        }

        private bool isBreakLoop(DateTime st)
        {
            bool rtn = false;

            DateTime tt = DateTime.Now;
            TimeSpan ts;
            ts = tt - st;
            double mt = ts.TotalSeconds;

            if(mt > maxdelaysecond)
                rtn = true;

            return rtn;

        }

        #endregion 

        #region Import File

        public SigmaResultType AddDrawing(string fileUrl, string exportfilepath)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            DataTable dt = new DataTable();
            DataTable tmpDt = new DataTable();
            SigmaResultType result = new SigmaResultType();

            dt = Element.Shared.Common.ImportHelper.ImportWorkSheet(fileUrl, true);

            DataTable tmpdt = new DataTable();
            tmpdt = dt.Copy();
            tmpdt.Rows.Clear();
            tmpdt.Columns.Add("Fail reason");

            int failCnt = 0;

            foreach (DataRow r in dt.Rows)
            {
                TypeDrawing obj = new TypeDrawing();
                obj.CWP = r[0].ToString();
                obj.Name = r[1].ToString();
                obj.Revision = r[2].ToString();
                obj.FileName = r[3].ToString();
                obj.Title = r[4].ToString();
                obj.DrawingType = r[5].ToString();
                obj.Description = r[6].ToString();


                if (string.IsNullOrEmpty(GetFailreasonForRequired(r)))
                {
                    SigmaResultType rst = AddDrawing(obj);

                    if (!string.IsNullOrEmpty(rst.ErrorMessage) && rst.ErrorMessage != "Success")
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
            ImportHistory.ImportCategory = "DRAWING";
            ImportHistory.ImportedFileName = Path.GetFileName(fileUrl).ToString();
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
                Export2Excel.ConvertExcelfromData(tmpdt, result.ScalarValue + Path.GetExtension(fileUrl), exportfilepath);

                //csv file generate for import error list view
                Export2Excel.ConvertCSVFile(tmpdt, result.ScalarValue + ".csv", exportfilepath);

            }

            return result;
        }

        public SigmaResultType AddDrawing(TypeDrawing objDrawing)
        {
            TypeUserInfo userinfo = AuthMgr.GetUserInfo();

            TransactionScope scope = null;
            SigmaResultType result = new SigmaResultType();

            // Get connection string
            string connStr = ConnStrHelper.getDbConnString();

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@ImportedSourceFileInfoID", 0));
            paramList.Add(new SqlParameter("@CwpName", objDrawing.CWP));
            paramList.Add(new SqlParameter("@Name", objDrawing.Name));
            paramList.Add(new SqlParameter("@FileName", objDrawing.FileName));
            paramList.Add(new SqlParameter("@Title", objDrawing.Title));
            paramList.Add(new SqlParameter("@Description", objDrawing.Description));
            paramList.Add(new SqlParameter("@Revision", objDrawing.Revision));
            paramList.Add(new SqlParameter("@DrawingType", objDrawing.DrawingType));
            paramList.Add(new SqlParameter("@CreatedBy", userinfo.SigmaUserId));
            paramList.Add(new SqlParameter("@ProjectId", userinfo.CurrentProjectId));
            paramList.Add(new SqlParameter("@ResultMsg", SqlDbType.VarChar, 100));
            paramList.Add(new SqlParameter("@DrawingId", SqlDbType.Int));
            paramList[10].Direction = ParameterDirection.Output;
            paramList[11].Direction = ParameterDirection.Output;

            using (scope = new TransactionScope(TransactionScopeOption.Required))
            {
                result.AffectedRow = SqlHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "usp_AddDrawing", paramList.ToArray());
                result.ErrorMessage = paramList[10].Value.ToString();
                result.IsSuccessful = true;

                scope.Complete();
            }

            return result;
        }

        private string GetFailreasonForRequired(DataRow r)
        {
            string rslt = string.Empty;
            if (string.IsNullOrEmpty(r[0].ToString()))
                rslt += "CWP,";
            if (string.IsNullOrEmpty(r[1].ToString()))
                rslt += "Drawing Number,";
            if (string.IsNullOrEmpty(r[2].ToString()))
                rslt += "Revision,";
            if (string.IsNullOrEmpty(r[3].ToString()))
                rslt += "File Name,";
            if (string.IsNullOrEmpty(r[4].ToString()))
                rslt += "Drawing Title,";
            if (string.IsNullOrEmpty(r[5].ToString()))
                rslt += "Drawing Type,";
            if (string.IsNullOrEmpty(r[6].ToString()))
                rslt += "Drawing Description,";

            rslt = rslt.Length > 0 ? rslt.Substring(0, rslt.Length - 1) + " is required." : string.Empty;
            return rslt;
        }

        #endregion
    }
}

